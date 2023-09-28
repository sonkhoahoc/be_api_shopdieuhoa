using System.Text.Json;
using System.Text.Json.Serialization;

namespace DADH.Extensions
{
    public class Common
    {
        public enum POSTable
        {
            Product,
            Product_Warehouse,
            Warehouse_Export_Product,
        }
        
    }

    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            DateTime datetime;
            if (DateTime.TryParse(reader.GetString(), out datetime))
            {
                return datetime;
            }
            return DateTime.MinValue;
            
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssZ"));
        }
    }
    

}
