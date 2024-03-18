using FrontEnd.Interface;
using FrontEnd.Model.BL;
using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages;

public partial class Rating
{
    
    [Parameter] 
    public string? Id {get;set;}
    
    [Inject]
    private IRatingService? RatingService { get; set; } 
    
   
    private List<RatingViewBl>? RatingView { get; set; }
    protected override async  Task OnInitializedAsync()
    {
        if (string.IsNullOrWhiteSpace(this.Id) && this.RatingService != null)
        {
            
        }
        else
        {
            this.RatingView = await this.RatingService?.GetRatingsView(this.Id);
        }
       
    }
 
    
    
}