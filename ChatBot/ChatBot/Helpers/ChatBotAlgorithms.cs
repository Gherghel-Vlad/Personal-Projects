using MayorAssistantApp.DAL;
using MayorAssistantApp.Models.ChatBotModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MayorAssistantApp.Helpers
{
    public static class ChatBotAlgorithms
    {
        public static QA GetNextQuestion(QA parentQA, string response)
        {
            Dictionary<QA, int> dic = new Dictionary<QA, int>();
            QA selectedQuestion;
            List<QA> questionList = new List<QA>();

            //Gets every word from the response and puts it in a array of type string
            string[] words = response.Split(' ', ',');

            //Gets all the responses
            if(parentQA.ComponentType == 0)
            {
                return QADB.GetQAById(parentQA.QAResponseId);
            }
            else
            {
                selectedQuestion = QADB.GetQAById(parentQA.QAResponseId);
                questionList = QADB.GetQAByComponentGroupId(selectedQuestion.ComponentGroupId);
            }

            int ok = 0;
            foreach(var w in words)
            {
                foreach(var qa in questionList)
                {
                    foreach(var word in qa.Keywords)
                    {
                        if(word!= "")
                            if (w.ToLower().Contains(word))
                            {
                                ok = 1;
                                break;
                            }
                    }

                    if(qa.Keywords.Contains(w.ToLower())||ok==1)
                    {
                        if (dic.ContainsKey(qa))
                        {
                            if (dic.TryGetValue(qa, out int value))
                            {
                                dic[qa] = value + 1;
                            }
                            else
                            {
                                dic[qa] = 1;
                            }
                        }
                        else
                        {
                            dic.Add(qa, 1);
                        }
                    }
                    ok = 0;
                }
            }


            if (dic.Count >= 1)
                return dic.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            else
            {
                QA defaultQA = new QA();
                defaultQA = parentQA;
                defaultQA.QAText = "Nu am inteles raspunsul. Va rog reformulati-l.";
                return defaultQA;
            }

        }


    }
}


//foreach (var w in words)
//{
//    selectedQuestion = questionList.FirstOrDefault(q => q.Keywords.Contains(w.ToLower()));

//    if (selectedQuestion != null)
//    {
//        if (dic.ContainsKey(selectedQuestion))
//        {
//            if (dic.TryGetValue(selectedQuestion, out int value))
//            {
//                dic[selectedQuestion] = value + 1;
//            }
//            else
//            {
//                dic[selectedQuestion] = 1;
//            }
//        }
//        else
//        {
//            dic.Add(selectedQuestion, 1);
//        }
//    }


//}