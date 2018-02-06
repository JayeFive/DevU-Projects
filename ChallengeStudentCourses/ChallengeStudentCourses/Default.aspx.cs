using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeStudentCourses
{
    public partial class Default : System.Web.UI.Page
    {
        List<Course> courses = new List<Course>()
            {
                new Course { CourseId = 101, Name = "Biology", Students = new List<Student>() {
                    new Student { StudentId = 1001, Name = "Johnny Olson" },
                    new Student { StudentId = 1002, Name = "Joshua Cloudt" } } },
                new Course { CourseId = 102, Name = "Calculus" , Students = new List<Student>() {
                    new Student { StudentId = 1003, Name = "Abby Ahearn" },
                    new Student { StudentId = 1004, Name = "Michelle Montalto"} } },
                new Course { CourseId = 103, Name = "Latin", Students = new List<Student>() {
                    new Student { StudentId = 1004, Name = "Bo Bryant" },
                    new Student { StudentId = 1005, Name = "Chris Condiss"} } }
            };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void assignment1Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a List of Courses (add three example Courses ...
             * make up the details).  Each Course should have at least two
             * Students enrolled in them.  Use Object and Collection
             * Initializers.  Then, iterate through each Course and print
             * out the Course's details and the Students that are enrolled in
             * each Course.
             */
            
            foreach (var course in courses)
            {
                resultLabel.Text += String.Format("<br />Course: {0} - {1}", course.CourseId, course.Name);
                foreach(var student in course.Students) 
                {
                    resultLabel.Text += String.Format("<br />&nbsp;&nbsp;Student: {0} - {1}", student.StudentId, student.Name);
                }
            }


            
        }

        protected void assignment2Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a Dictionary of Students (add three example Students
             * ... make up the details).  Use the StudentId as the 
             * key.  Each student must be enrolled in two Courses.  Use
             * Object and Collection Initializers.  Then, iterate through
             * each student and print out to the web page each Student's
             * info and the Courses the Student is enrolled in.
             */

            Course Course1 = new Course() { CourseId = 101, Name = "Biology" };
            Course Course2 = new Course() { CourseId = 102, Name = "Calculus" };
            Course Course3 = new Course() { CourseId = 103, Name = "Latin" };

            Dictionary<int, Student> students = new Dictionary<int, Student>()
            {
                { 1001, new Student() { StudentId = 1001, Name = "Johnny Olson", Courses = new List<Course> { Course1, Course2 } } },
                { 1002, new Student() { StudentId = 1002, Name = "Joshua Cloudt", Courses = new List<Course> { Course2, Course3 } } },
                { 1003, new Student() { StudentId = 1003, Name = "Bryan Reed", Courses = new List<Course> {Course2, Course3}} }
            };

            foreach(var student in students)
            {
                resultLabel.Text += String.Format("<br /> Student:{0} - {1}", student.Key, student.Value.Name);
                foreach(var course in student.Value.Courses)
                {
                    resultLabel.Text += String.Format("<br />&nbsp;&nbsp; Course: {0} - {1}", course.CourseId, course.Name);
                }
            }
        }

        protected void assignment3Button_Click(object sender, EventArgs e)
        {
            /*
             * We need to keep track of each Student's grade (0 to 100) in a 
             * particular Course.  This means at a minimum, you'll need to add 
             * another class, and depending on your implementation, you will 
             * probably need to modify the existing classes to accommodate this 
             * new requirement.  Give each Student a grade in each Course they
             * are enrolled in (make up the data).  Then, for each student, 
             * print out each Course they are enrolled in and their grade.
             */ 


        }
    }
}