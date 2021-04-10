using System;
using System.Collections.Generic;
public class Building
{
    public long id { get; set; }
    public string adm_contact_full_name {get; set; }
    public string adm_contact_email { get; set; }
    public string adm_contact_phone { get; set; }
    public string tech_contact_full_name { get; set; }  
    public string tech_contact_email { get; set; }
    public string tech_contact_phone { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public long? customer_id { get; set; }
    public long? address_id { get; set; }
    public virtual ICollection<Battery> Batteries { get; set;}
    public  Customer Customer { get; set; }
}