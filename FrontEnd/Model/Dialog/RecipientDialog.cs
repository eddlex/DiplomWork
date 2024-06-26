﻿using FrontEnd.Helpers;
using FrontEnd.Model.BL;

namespace FrontEnd.Model.Dialog;

public class RecipientDialog
{
    public string? Name { get; set; }
    public string? Mail { get; set; }
    public Select<RecipientGroup> Group { get; set; }
    public Select<DepartmentBl> Department { get; set; }

    public string? Description { get; set; }
    public Select<Weight> Weight { get; set; }

}