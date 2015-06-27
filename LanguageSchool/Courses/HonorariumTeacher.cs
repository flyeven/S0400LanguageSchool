using LanguageSchool.People;
using System;
using System.Collections.Generic;


namespace LanguageSchool.Courses
{
    public class HonorariumTeacher
    {
        private static List<HonorariumTeacher> honorariesTeachers = new List<HonorariumTeacher>();
        private ulong teacherId;
        private ulong courseId;
        private Teacher teacher;
        private Course course;
        private decimal honorariumPerHour;

        public HonorariumTeacher(Teacher teacher, Course course, decimal honorariumPerHour)
        {
            this.Teacher = teacher;
            this.Course = course;
            this.HonorariumPerHour = honorariumPerHour;
            this.TeacherId = this.CalculateTeacherId();
            this.CourseId = this.CalculateCourseId();
        }

        public ulong TeacherId
        {
            get
            {
                return this.teacherId;
            }

            set
            {
                this.teacherId = value;
            }
        }
        public ulong CourseId
        {
            get
            {
                return this.courseId;
            }

            set
            {
                this.courseId = value;
            }
        }
           
        public Teacher Teacher
        {
            get
            {
                return this.teacher;
            }

            set
            {
                this.teacher = value;
            }
        }
        public Course Course
        {
            get
            {
                return this.course;
            }

            set
            {
                this.course = value;
            }
        }
        public decimal HonorariumPerHour
        {
            get
            {
                return this.honorariumPerHour;
            }

            set
            {
                this.honorariumPerHour = value;
            }
        }

        private ulong CalculateTeacherId()
        {
            ulong id = this.teacher.Id;

            return id;
        }

        private ulong CalculateCourseId()
        {
            ulong id = this.course.Id;

            return id;
        }

        public static bool HonoraryCheck(ulong courseId, ulong teacherId)
        {
            bool output = false;

            foreach (var item in HonorariumTeacher.honorariesTeachers)
            {
                if (item.CourseId == courseId && item.TeacherId == teacherId)
                {
                    output = true;
                    break;
                }
            }

            return output;
        }

        public static void AddHonorariumToBase(HonorariumTeacher honorarium)
        {
            HonorariumTeacher.honorariesTeachers.Add(honorarium);
        }

        public static List<HonorariumTeacher> GetHonorariumList()
        {
            return HonorariumTeacher.honorariesTeachers;
        }
    }
}
