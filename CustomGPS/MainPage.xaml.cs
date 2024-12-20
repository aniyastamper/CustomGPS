namespace CustomGPS;

public partial class MainPage : ContentPage
{
    private GeolocationRequest request; //This will be our main level variable 

    public MainPage()
    {
        InitializeComponent();

        request = new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(10));

    }
    
    


    private async void UpdateLocation_OnClicked(object sender, EventArgs e)
    {
        Location location = await Geolocation.Default.GetLocationAsync(request); //We want to finish this tracker before we continue with code 

        lblLat.Text = location.Latitude.ToString(); //Will identify and locate the direct Lat location and populatte it in that Label
        lblLon.Text = location.Longitude.ToString(); //Will Identify and locate the direct Lon location 

        var placemarks = await Geocoding.Default.GetPlacemarksAsync( location.Latitude, location.Longitude);
        var placemark = placemarks?.FirstOrDefault();

        lbladdress1.Text = placemark.SubThoroughfare + " " + placemark.Thoroughfare; // Sub is the addy # , Throughfare is the Street

        lbladdress2.Text = placemark.Locality + " " +placemark.AdminArea + " " +placemark.PostalCode; //Locality is the City , Admin Area is is the State and Postal code is code 
    }
}