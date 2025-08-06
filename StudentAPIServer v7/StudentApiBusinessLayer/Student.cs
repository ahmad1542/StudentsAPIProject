using StudentDataAccessLayer;

namespace StudentApiBusinessLayer {
    public class Student {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
    }
}
