using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;

namespace SpecialFolderDemo
{
    [Activity(Label = "SpecialFolderDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView tv1;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button saveBt = FindViewById<Button>(Resource.Id.savebt);
            Button showBt = FindViewById<Button>(Resource.Id.showbt);
            tv1 = FindViewById<TextView>(Resource.Id.textView1);

            saveBt.Click += SaveBt_Click;
            showBt.Click += ShowBt_Click;
        }

        private void ShowBt_Click(object sender, System.EventArgs e)
        {
            DeSerializeObject();
        }

        private void SaveBt_Click(object sender, System.EventArgs e)
        {
            SerializeObject();
        }

        public void SerializeObject()
        {
       
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, "data.txt");
            System.IO.File.WriteAllText(filePath, "Hello Mike Ma");
        }


        public void DeSerializeObject()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, "data.txt");
            string text = System.IO.File.ReadAllText(filePath);

            tv1.Text = text;
        }
    }
}

