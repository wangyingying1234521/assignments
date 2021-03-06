// Course.cs - Chapter 14 version.

// Copyright 2008 by Jacquie Barker  and Grant Palmer - all rights reserved.

// A MODEL class.

using System;
using System.Collections.Generic;

public class Course
{

    //----------------
    // Constructor(s).
    //----------------

    public Course(string cNo, string cName, double credits)
    {

        //  Initialize property values.

        CourseNumber = cNo;
        CourseName = cName;
        Credits = credits;

        // Create two empty Lists.

        OfferedAsSection = new List<Section>();
        Prerequisites = new List<Course>();
    }

    //-------------------------------
    // Auto-implemented properties.
    //-------------------------------

    public static int sectionNo = 0;
    public string CourseNumber { get; set; }
    public string CourseName { get; set; }
    public double Credits { get; set; }
    public List<Section> OfferedAsSection { get; set; }
    public List<Course> Prerequisites { get; set; }

    //-----------------------------
    // Miscellaneous other methods.
    //-----------------------------

    // Used for testing purposes.

    public void Display()
    {
        Console.WriteLine("Course Information:");
        Console.WriteLine("\tCourse No.:  " + CourseNumber);
        Console.WriteLine("\tCourse Name:  " + CourseName);
        Console.WriteLine("\tCredits:  " + Credits);
        Console.WriteLine("\tPrerequisite Courses:");

        // We use a foreach statement to step through the prerequisites.

        foreach (Course c in Prerequisites)
        {
            Console.WriteLine("\t\t" + c.ToString());
        }

        // Note use of Write vs. WriteLine in next line of code.

        Console.Write("\tOffered As Section(s):  ");
        for (int i = 0; i < OfferedAsSection.Count; i++)
        {
            Section s = (Section)OfferedAsSection[i];
            Console.Write(s.SectionNumber + " ");
        }

        // Print a blank line.
        Console.WriteLine("");
    }

    //**************************************
    //
    public override string ToString()
    {
        return CourseNumber + ":  " + CourseName;
    }

    //**************************************
    //
    public void AddPrerequisite(Course c)
    {
        if (this != c)
        {
            Prerequisites.Add(c);
        }
        else
        {
            Console.WriteLine("选修的课程不能设自己为先修课！！！");
        }

    }

    //**************************************
    //
    public bool HasPrerequisites()
    {
        if (Prerequisites.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //******************************************************************
    //
    public Section ScheduleSection(string day, string time, string room,
                         int capacity)
    {
        // Create a new Section (note the creative way in
        // which we are assigning a section number) ...
        //保证选课号各不相同（练习4）
        sectionNo = sectionNo + 1;
        Section s = new Section(sectionNo,
                    day, time, this, room, capacity);

        // ... and then add it to the List
        OfferedAsSection.Add(s);

        return s;
    }



    //练习4
    public void CancelSection(Section s)
    {
        //该课程从选课列表中移除
        OfferedAsSection.Remove(s);
        //选课项从选课列表中移除
        s.OfferedIn.SectionsOffered.Remove(s.RepresentedCourse.CourseNumber +
                   " - " + s.SectionNumber);

        Console.WriteLine("该课程已成功移出选课列表！");

    }



}
