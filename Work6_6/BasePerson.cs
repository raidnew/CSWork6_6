namespace Work6_6
{
    public class BasePerson
    {
        protected static char separator = '#';
        protected virtual string[] GetDataAsStringArray()
        {
            return null;
        }
        
        public string GetSerializedString()
        {
            string serializedString = "";
            bool first = true;
            
            foreach (var data in GetDataAsStringArray())
            {
                if (!first) serializedString += separator;
                serializedString += data;
                first = false;
            }

            return serializedString;
        }
    }
}