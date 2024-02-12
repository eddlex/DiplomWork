﻿using System.ComponentModel.DataAnnotations;
using FrontEnd.Helpers;

namespace FrontEnd.Model;

public class Department
{
    [CustomAttributes.EnumValue]
    public int Id { get; set; }
    
    
    [CustomAttributes.EnumKey]
    public string Name { get; set; }
    public string Description { get; set; }
    
    public Department(int id, string name, string description)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
    }
}

