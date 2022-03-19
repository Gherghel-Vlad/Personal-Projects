using MayorAssistantApp.DAL;
using MayorAssistantApp.Helpers;
using MayorAssistantApp.Models.ChatBotModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MayorAssistantApp.Controllers.Api
{
    public class ChatbotController : ApiController
    {
        // GET: api/Chatbot
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Chatbot/5
        /// <summary>
        /// Gets all the responses a question has(if it has)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<QA> Get(int id)
        {
            // this list will contain all the QAs from the table that are
            //the response for the id that it has been given
            List<QA> list = new List<QA>();

            //this will be the first QA taken
            QA qa = new QA();

            //getting the first QA
            qa = QADB.GetQAById(id);

            // Checks if there s atleast a response
            if (qa.QAResponseId == 0)
            {
                //this will return a QA object with QAid -1 if there are no responses

                QA nullQA = new QA();
                nullQA.QAId = -1;

                list.Add(nullQA);
            }
            else
            {
                // checks if there are other responses
                if (qa.ComponentType == 1)
                {
                    //if there are, it will gather all the responses
                    list = QADB.GetQAByComponentGroupId(QADB.GetQAById(qa.QAResponseId).ComponentGroupId);
                }
                else
                {
                    //if there are not, it will return a list containing only that QA element
                    list.Add(QADB.GetQAById(qa.QAResponseId));
                }
            }

            return list;
        }

        [Route("api/chatbot/getqabyid/{id:int}")]
        [HttpGet]
        /// <summary>
        /// Gets the QA by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QA GetQAById(int id)
        {
            QA qa = new QA();

            qa = QADB.GetQAById(id);

            return qa;
        }


        // POST: api/Chatbot
        public HttpStatusCode Post([FromBody]QAPostObj qa)
        {
            //gets the parent qa where the answer/question will be added
            QA QAParent = QADB.GetQAById(qa.QAParentId);

            //the variable that creates the unique
            Guid guid = new Guid();
            guid = Guid.NewGuid();

            //creating a list of the keywords
            var ewords = qa.Keywords.Split(',', ' ');
            List<string> words = new List<string>();
            foreach (var word in ewords)
            {
                if (word != "")
                {
                    words.Add(word);
                }
            }

            //creating the default element that will be inserted
            QA insertQA = new QA()
            {
                QAId = 0,
                QAText = qa.QAText,
                QAResponseId = 0,
                Context = "",
                FlowId = "",
                ComponentType = 0,
                ComponentGroupId = "",
                Keywords = words
            };

            //gets the parent QA
            QA parentQA = new QA();
            parentQA = QADB.GetQAById(qa.QAParentId);

            //if it doesnt have a response, it will have this one
            if (QAParent.QAResponseId == 0)
            {
                //puts a ComponentGroupId of type guid
                insertQA.ComponentGroupId = guid.ToString();

                //Checks if the the parent is the FIRST quesiton, that means it s a new flow
                if (parentQA.QAId == 1)
                {
                    guid = Guid.NewGuid();
                    insertQA.FlowId = guid.ToString();
                }

                // adds the new QA and gets its QAId
                int insertedqaid = QADB.InsertQAAndReturnTheId(insertQA);

                //update the parent qa with the new response
                parentQA.QAResponseId = insertedqaid;
                QADB.UpdateQA(parentQA);

            }
            else
            {
                // gets the response of the question so that it can use the ComponentGroupId etc
                QA brotherQA = new QA();
                brotherQA = QADB.GetQAById(parentQA.QAResponseId);

                //sets the values of the insertedQa
                insertQA.ComponentGroupId = brotherQA.ComponentGroupId;

                //if the parent is the FIRST question, the flow wont be the same
                if (parentQA.QAId != 1)
                {
                    insertQA.FlowId = brotherQA.FlowId;
                }

                //Checks if the the parent is the FIRST quesiton, that means it s a new flow
                if (parentQA.QAId == 1)
                {
                    guid = Guid.NewGuid();
                    insertQA.FlowId = guid.ToString();
                }

                //inserts the insertQA
                QADB.InsertQA(insertQA);

                //changes the ComponentType of the parent (now it will have at least 2 reponse)
                parentQA.ComponentType = 1; //this represents that it s a question of type switch
                QADB.UpdateQA(parentQA);

            }



            return HttpStatusCode.OK;
        }

        // PUT: api/Chatbot/5
        public void Put(int id, [FromBody]QAPostObj qa)
        {

            //creating a list of the keywords
            var ewords = qa.Keywords.Split(',', ' ');
            List<string> words = new List<string>();
            foreach (var word in ewords)
            {
                if (word != "")
                {
                    words.Add(word);
                }
            }

            //getting the current question/answer
            QA currentQA = new QA();
            currentQA = QADB.GetQAById(id);

            //modifing the currentQA
            currentQA.Keywords = words;
            currentQA.QAText = qa.QAText;

            //updating the QA
            QADB.UpdateQA(currentQA);

        }

        // DELETE: api/Chatbot/5
        public void Delete(int id)
        {
        }


        // api/Chatbot/Response/1

        [Route("api/chatbot/getresponse/{id:int}")]
        [HttpPost]
        public QA GetResponse(int id, [FromBody]StringObj answer)
        {
            if (id == -1)
                return QADB.GetQAById(1);
            else
                return ChatBotAlgorithms.GetNextQuestion(QADB.GetQAById(id), answer.Answer);
        }
    }

    #region Classes

    public class QAPostObj
    {
        public string QAText { get; set; }
        public string Keywords { get; set; }
        public int QAParentId { get; set; }
    }
    public class StringObj
    {
        public string Answer { get; set; }
    }

    #endregion

}


