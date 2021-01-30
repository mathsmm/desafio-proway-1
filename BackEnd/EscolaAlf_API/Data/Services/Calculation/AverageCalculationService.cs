using System;
using System.Collections.Generic;
using EscolaAlf_API.Data.Interfaces;

namespace EscolaAlf_API.Data.Services
{
    public class AverageCalculationService
    {
        private readonly IStudentGrade _iStudentGrade;
        private readonly IStudentSituation _iStudentSituation;
        public AverageCalculationService(IStudentGrade iStudentGrade, IStudentSituation iStudentSituation)
        {
            this._iStudentGrade = iStudentGrade;
            this._iStudentSituation = iStudentSituation;
        }
        public AverageCalculationService() {}

        public double ReturnAverage(List<double> gradeList)
        {
            double gradeSum = 0;
            foreach (var grade in gradeList)
            {
                gradeSum = gradeSum + grade;
            }
            return gradeSum / gradeList.Count;
        }

        public double CalculateAverageOfAStudent(int studentId)
        {
            List<double> gradeList = _iStudentGrade.ReturnGradesOfAStudent(studentId);
            return ReturnAverage(gradeList);
        }
    }
}