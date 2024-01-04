using System;

namespace Work6_6
{
    public class Employee : BasePerson
    {
        private static ulong _nextId = 0;
        
        private ulong _id;
        private DateTime _dateAdded;
        private string _fullName;
        private byte _age;
        private ushort _height;
        private DateTime _dateOfBirth;
        private string _placeOfBirth;

        public ulong Id => _id;
        public DateTime DateAdded => _dateAdded;
        public string FullName => _fullName;
        public byte Age => _age;
        public ushort Height => _height;
        public DateTime DateOfBirth => _dateOfBirth;
        public string PlaceOfBirth => _placeOfBirth;

        public static void InitId(string serializedSrting)
        {
            try
            {
                Employee tempEmployee = new Employee(serializedSrting);
                _nextId = (tempEmployee.Id) + 1;
            }
            catch (FormatException e)
            {
                
            }
        }
        
        public Employee(string serializedString)
        {
            ParseSerializedString(serializedString);
        }

        public Employee(string fullName, byte age, ushort heignt, DateTime dateOfBirth, string placeOfBirth)
        {
            _id = _nextId++;
            _fullName = fullName + _id;
            _age = age; //TODO may be calculate?
            _height = heignt;
            _dateOfBirth = dateOfBirth;
            _placeOfBirth = placeOfBirth;
            _dateAdded = DateTime.Now;
        }

        private void ParseSerializedString(string serializedString)
        {
            try
            {
                string[] data = serializedString.Split(separator);
                _id = Convert.ToUInt64(data[0]);
                _dateAdded = DateTime.Parse(data[1]);
                _fullName = Convert.ToString(data[2]);
                _age = Convert.ToByte(data[3]);
                _height = Convert.ToUInt16(data[4]);
                _dateOfBirth = DateTime.Parse(data[5]);
                _placeOfBirth = Convert.ToString(data[6]);
            }
            catch (FormatException e)
            {
                
            }
        }

        protected override string[] GetDataAsStringArray()
        {
            return new string[]
            {
                _id.ToString(),
                _dateAdded.ToString(),
                _fullName,
                _age.ToString(),
                _height.ToString(),
                _dateOfBirth.ToString(),
                _placeOfBirth,
            };
        }
        

    }
}