using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ImageGenerator
{
    public partial class MainPage : ContentPage
    {
        private Image? pairs;

        /// <summary>
        /// List created with 5 items, to be shown randomly on button click.
        /// </summary>
        

        
        List<Image> images = new List<Image>()
        {
                new Image("image1", "Man" ),
                new Image("image2", "Bird" ),
                new Image("image3", "Big cat" ),
                new Image("image4", "Autumn road" ),
                new Image("image5", "Flowergirl")
        };
        

        private Random random = new();

        public MainPage()
        {
            
            InitializeComponent();
        }

        private void ImageOnClicked(object? sender, EventArgs e)
        {
            ShowImageAndText();
        }

        private void ShowImageAndText()
        {

            //var singleKeys = ImageList.Keys.ToList(); // en lokal lista av det första paret i en Dictionary

            pairs = images.ElementAt(random.Next(images.Count));

            Debug.WriteLine(pairs.Key + ": " + pairs.Value); // för testning i Output

            string showKey = GetImageFileEnding(pairs.Key); // detta då enbart Windows kräver filändelse

            ShowGallery.Source = showKey;

            ImageText.Text = pairs.Value;



            FavoriteButton.Source = new FontImageSource
            {
                Glyph = pairs.IsFavorite ? "\ue87d" : "\ue87e",
                FontFamily = "MaterialIcons",
                Size = 32,
                Color = pairs.IsFavorite ? Colors.Red : Colors.Gray
            };
        }

        private string GetImageFileEnding(string imageKey)
        {
            #if WINDOWS
            return imageKey + ".jpg";
            #else
            return imageKey;
            #endif
        }


        private void OnFavoriteClicked(object sender, EventArgs e)
        {
            

                if (pairs == null)
            
                return;

                pairs.IsFavorite = !pairs.IsFavorite;


                FavoriteButton.Source = new FontImageSource
                {
                    Glyph = pairs.IsFavorite ? "\ue87d" : "\ue87e",
                    FontFamily = "MaterialIcons",
                    Size = 32,
                    Color = pairs.IsFavorite ? Colors.Red : Colors.Gray
                };
            
           
            
        }

        public class Image
            {
                public string Key { get; set; }
                public string Value { get; set; }
                public bool IsFavorite { get; set; }
            public Image(string key, string value)
            {
                    Key = key;
                    Value = value;
                    IsFavorite = false;
            }
            }
    }
}
