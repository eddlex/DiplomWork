
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace FrontEnd.Pages;

public partial class Index
{
    public class SampleValue
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
    public List<SampleValue> SampleValues = new List<SampleValue>(){
        new SampleValue{Id=1, Description="Pants"},
        new SampleValue{Id=2, Description="Pantalones"},
        new SampleValue{Id=3, Description="Broek"},
        new SampleValue{Id=4, Description="Hosen"},
        new SampleValue{Id=5, Description="Housut"},
        new SampleValue{Id=6, Description="Buxur"},
        new SampleValue{Id=7, Description="Bikses"},
        new SampleValue{Id=8, Description="Kelnės"},
        new SampleValue{Id=9, Description="Nadrág"},
        new SampleValue{Id=10,Description="Drathais"},
        new SampleValue{Id=11,Description="Byxor"},
        new SampleValue{Id=12,Description="Ishton"},
        new SampleValue{Id=13,Description="Pataloha"},
        new SampleValue{Id=14,Description="Shorts"},
        new SampleValue{Id=15,Description="Commando"}
    };
    public SampleValue MudCardValue1;
    public SampleValue MudCardValue2;
    public SampleValue DivValue1;
    public SampleValue DivValue2;

    Func<SampleValue, string> SampleDisplayConverter = p => p?.Description;

    protected override void OnInitialized()
    {
        MudCardValue1 = SampleValues.FirstOrDefault(x => x.Id == 1);
        MudCardValue2 = SampleValues.FirstOrDefault(x => x.Id == 2);

        DivValue1 = SampleValues.FirstOrDefault(x => x.Id == 3);
        DivValue2 = SampleValues.FirstOrDefault(x => x.Id == 4);

        base.OnInitialized();
    }
}

// DialogWithSelect.razor.cs



