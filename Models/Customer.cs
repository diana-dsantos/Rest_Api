using System;
using System.Collections.Generic;
public class Customer
{
    public long id { get; set; }
    public DateTime? date_create { get; set; }
    public string company_name { get; set; }
    public string cpy_contact_full_name { get; set; }
    public string cpy_contact_phone { get; set; }
    public string cpy_contact_email { get; set; }
    public string cpy_description { get; set; }
    public string tech_authority_service_full_name { get; set; }
    public string tech_authority_service_phone { get; set; }
    public string tech_manager_service_email { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public long? user_id { get; set; }
    public long? address_id { get; set; }
    public virtual ICollection<Building> Buildings { get; set; }
}