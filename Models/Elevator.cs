using System;
public class Elevator
{
    public long id { get; set; }
    public string serial_number {get; set; }
    public string model { get; set; }
    public string type_building { get; set; }
    public string status { get; set; }     
    public DateTime? date_commissioning {get; set; }
    public DateTime? date_last_inspection { get; set; }
    public string certificate_inspection { get; set; }
    public string information { get; set; }
    public string notes { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public long? column_id { get; set; }
    
    [System.Text.Json.Serialization.JsonIgnore]
    public  Column Column { get; }
}