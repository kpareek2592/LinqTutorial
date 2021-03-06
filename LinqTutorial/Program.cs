﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LinqTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            #region any operator with primitive data types
            
            List<string> data = new List<string>() { "Kim", "Adam", "Jacob"};
            var containsKim = data.Contains("Kim");
            var containsRahul = (from person in data
                                 select person).Contains("Rahul");

            #endregion

            #region order by with class

            List<Student> students = new List<Student>()
            {
                new Student{
                    Name="Kim", Marks=90
                },
                new Student{
                    Name="John", Marks=80
                },
                new Student{
                    Name="Lee", Marks=75
                }
            };

            var stu = new Student() { Name = "Tom", Marks = 65 };
            students.Add(stu);

            var comparer = new StudentComparer();

            //contains marks 90
            //The below one should be true but it comes out to be false as .Contains checks reference 
            //    and since we are declaring new Student()
            //    inside it the reference is differnet
            var ms = students.Contains(new Student() { Name = "Lee", Marks = 75 });
            var ms1 = students.Contains(stu); //This returns true as reference to stu is same

            var ms2 = students.Contains(new Student() { Name = "Lee", Marks = 75 }, comparer); //returns true as we are using comparer

                     #endregion

            Console.ReadKey();
        }
    }

    public class Student
    {
        public int Marks { get; set; }
        public string Name { get; set; }
    }

    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals([AllowNull] Student x, [AllowNull] Student y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }
            if(object.ReferenceEquals(x,null) || object.ReferenceEquals(y, null))
            {
                return false;
            }

            return x.Name == y.Name && x.Marks == y.Marks;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            if (object.ReferenceEquals(obj, null))
                return 0;

            int marksHashCode = obj.Marks.GetHashCode();
            int nameHashCode = obj.Name == null ? 0 : obj.Name.GetHashCode();

            return marksHashCode ^ nameHashCode;
        }
    }

}
