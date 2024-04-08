using FrontEnd.Interface;
using FrontEnd.Model.BL;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


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
            //WindowInnerHeight = await JSRuntime.InvokeAsync<int>("getWindowInnerHeight");
            //RowsPerPage = CalculateRowsPerPage();
            this.RatingView = await this.RatingService?.GetRatingsView(this.Id);
            if (!this.RatingView.Any())
                NavigationManager.NavigateTo("/SomethingWrong");
        }       
    }


    public async Task Submit()
    {
        var s = this.RatingView;
        var formIdentificationId = this.RatingView.First().FormIdentificationId;

        var ratingRows = new List<RatingRowBl>();
        this.RatingView.ForEach(r => ratingRows.Add(new ()
        {
            Id = r.RatingId,
            Value = r.RatingValue,
            FormRowId = r.FormRowId
        }));

        var ratingBl = new RatingBl
        {
            FormIdentificationId = formIdentificationId,
            RatingRows = ratingRows
        };
        
        var result = await this.RatingService.AddRatings(ratingBl);
        if(result)
        {
            NavigationManager.NavigateTo("/ThankYou");
        }
        else
        {
            NavigationManager.NavigateTo("/SomethingWrong");
        }
    }
    
}