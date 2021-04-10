using System;
public class Lead
{
    public long id { get; set; }
    public string full_name_of_contact { get; set; }
    public string company_name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string project_name { get; set; }
    public string project_description { get; set; }
    public string department_in_charge_of_elevators { get; set; }
    public string message { get; set; }
    // attachment
    public string file_name { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public long? customer_id { get; set; }

}