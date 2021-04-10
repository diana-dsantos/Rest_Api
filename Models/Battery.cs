using System;
using System.Collections.Generic;
public class Battery
{
    public long id { get; set; }
    public string type_building {get; set; }
    public string status { get; set; }    
    public DateTime? date_commissioning {get; set; }
    public DateTime? date_last_inspection { get; set; }
    public string certificate_operations { get; set; }
    public string information { get; set; }
    public string notes { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public long? employee_id { get; set; }
    public long? building_id { get; set; }
    public  Building Building { get; set;}
    public virtual ICollection<Column> Columns { get; set;}
}