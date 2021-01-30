using System;
using System.Collections.Generic;
using EscolaAlf_API.Data.Interfaces;

namespace EscolaAlf_API.Data.Services
{
    public class GradeCalculationService
    {
        private readonly DataContext _context;
        private readonly ITemplate _iTemplate;
        private readonly IStudentReply _iStudentReply;
        private readonly ITestQuestion _iTestQuestion;
        public GradeCalculationService(DataContext context, ITemplate iTemplate, IStudentReply iStudentReply, ITestQuestion iTestQuestion)
        {
            this._context = context;
            this._iTemplate = iTemplate;
            this._iStudentReply = iStudentReply;
            this._iTestQuestion = iTestQuestion;
        }
        public GradeCalculationService() {}
        public List<int> ReturnZeroOneNumberList(int testId, int studentId, List<int> templateOptionsId, List<int> replyOptionsId)
        {
            List<int> zeroOneList = new List<int>();
            for (int i = 0; i < replyOptionsId.Count; i++)
            {
                if (replyOptionsId[i] == templateOptionsId[i])
                {
                    zeroOneList.Add(1);
                }
                else
                {
                    zeroOneList.Add(0);
                }
            }
            return zeroOneList;
        }

        public double ReturnGrade(List<int> zeroOneList, List<int> weightList)
        {
            double sumQuestionWeight = 0;
            double sumWeights = 0;
            double grade = 0;
            for (int i = 0; i < weightList.Count; i++)
            {
                sumQuestionWeight = sumQuestionWeight + (zeroOneList[i] * weightList[i]);
                sumWeights = sumWeights + weightList[i];
            }
            grade = (sumQuestionWeight / sumWeights) * 10;
            return grade;
        }

        public double CalculateGradeOfOneStudent(int testId, int studentId, List<int> templateOptionsId, List<int> replyOptionsId)
        {
            return ReturnGrade(ReturnZeroOneNumberList(testId, studentId, templateOptionsId, replyOptionsId), _iTestQuestion.ReturnWeights(testId));
        }
    }
}