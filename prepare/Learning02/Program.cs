using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Apple";
        job1._jobTitle = "Software engineer";
        job1._startYear = 2020;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._company = "Microsoft";
        job2._jobTitle = "Junior Software engineer";
        job2._startYear = 2018;
        job2._endYear = 2020;

        Resume resume = new Resume();
        resume._name = "Bradley Gardner";
        resume._jobs = [job1, job2];
        resume.Display();
    }
}