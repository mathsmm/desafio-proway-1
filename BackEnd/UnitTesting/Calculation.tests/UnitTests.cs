using System.Collections.Generic;
using EscolaAlf_API.Data.Services;
using NUnit.Framework;

namespace Calculation.tests
{
    [TestFixture]
    public class UnitTests
    {
        private GradeCalculationService _gradeCalculationService;
        private AverageCalculationService _averageCalculationService;
        [SetUp]
        public void SetUp(){
            _gradeCalculationService = new GradeCalculationService();
            _averageCalculationService = new AverageCalculationService();
        }

        [Test]
        public void ReturnGrade_Test1()
        {
            List<int> zeroOneList = new List<int>();
            zeroOneList.Add(1);
            zeroOneList.Add(0);
            zeroOneList.Add(1);
            zeroOneList.Add(0);
            List<int> weightList = new List<int>();
            weightList.Add(5);
            weightList.Add(5);
            weightList.Add(10);
            weightList.Add(10);
            double result = _gradeCalculationService.ReturnGrade(zeroOneList, weightList);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void ReturnGrade_Test2()
        {
            List<int> zeroOneList = new List<int>();
            zeroOneList.Add(1);
            zeroOneList.Add(0);
            zeroOneList.Add(1);
            zeroOneList.Add(0);
            List<int> weightList = new List<int>();
            weightList.Add(15);
            weightList.Add(5);
            weightList.Add(10);
            weightList.Add(10);
            double result = _gradeCalculationService.ReturnGrade(zeroOneList, weightList);
            Assert.That(result , Is.EqualTo(6.25));
        }

        [Test]
        public void ReturnGrade_Test3()
        {
            List<int> zeroOneList = new List<int>();
            zeroOneList.Add(0);
            zeroOneList.Add(1);
            zeroOneList.Add(0);
            zeroOneList.Add(1);
            List<int> weightList = new List<int>();
            weightList.Add(25);
            weightList.Add(35);
            weightList.Add(15);
            weightList.Add(25);
            double result = _gradeCalculationService.ReturnGrade(zeroOneList, weightList);
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void ReturnGrade_Test4()
        {
            List<int> zeroOneList = new List<int>();
            zeroOneList.Add(0);
            zeroOneList.Add(1);
            zeroOneList.Add(0);
            zeroOneList.Add(1);
            zeroOneList.Add(0);
            zeroOneList.Add(1);
            List<int> weightList = new List<int>();
            weightList.Add(25);
            weightList.Add(15);
            weightList.Add(35);
            weightList.Add(25);
            weightList.Add(15);
            weightList.Add(35);
            double result = _gradeCalculationService.ReturnGrade(zeroOneList, weightList);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void ReturnAverage_Test1()
        {
            List<double> gradeList = new List<double>();
            gradeList.Add(10);
            gradeList.Add(10);
            gradeList.Add(10);
            gradeList.Add(0);
            double result = _averageCalculationService.ReturnAverage(gradeList);
            Assert.That(result, Is.EqualTo(7.5));
        }

        [Test]
        public void ReturnAverage_Test2()
        {
            List<double> gradeList = new List<double>();
            gradeList.Add(6.3);
            gradeList.Add(7.8);
            gradeList.Add(4.4);
            gradeList.Add(9.9);
            double result = _averageCalculationService.ReturnAverage(gradeList);
            Assert.That(result, Is.EqualTo(7.1));
        }

        [Test]
        public void ReturnAverage_Test3()
        {
            List<double> gradeList = new List<double>();
            gradeList.Add(8);
            gradeList.Add(6.5);
            gradeList.Add(7);
            gradeList.Add(9.25);
            gradeList.Add(5.75);
            double result = _averageCalculationService.ReturnAverage(gradeList);
            Assert.That(result, Is.EqualTo(7.3));
        }

        [Test]
        public void ReturnAverage_Test4()
        {
            List<double> gradeList = new List<double>();
            gradeList.Add(0);
            gradeList.Add(0);
            gradeList.Add(0);
            gradeList.Add(10);
            gradeList.Add(10);
            gradeList.Add(10);
            double result = _averageCalculationService.ReturnAverage(gradeList);
            Assert.That(result, Is.EqualTo(5));
        }
    }
}