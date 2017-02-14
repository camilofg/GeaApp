using Xamarin.Forms;

namespace XamarinForms.PortableXaml
{
    public class Detail : ContentPage
    {
        public Detail()
        {
            StackLayout sl = new StackLayout();

            SearchBar sb = new SearchBar();

            sl.Children.Add(sb);

            Content = sl;
        }
    }
}
