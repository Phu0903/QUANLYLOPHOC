using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDWebAPI
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ID_Class { get; set; }
        public string Birthday { get; set; }
        public string RegisterDay { get; set; }
        public string Gender { get; set; }
       /// <summary>
       /// ///////////
       /// </summary>
      
    }
    public class ClassStudent
    {
    public string ID_CLass { get; set; }
    public string NameClass { get; set; }
    public string StartDay { get; set; }
    public string LeavingDay { get; set; }
    public string Image { get; set; }
    }   

    public class Thongbao
    {
        public int Id_thongbao { get; set; }
        public string Tieude { get; set; }
        public string NoiDung { get; set; }
        public DateTime Time { get; set; }
    }
    /*public class Teacher
    {
        public string Name_Teacher { get; set; }
        public string BirthDay_Teacher { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Chucvu { get; set; }
    }*/
}
