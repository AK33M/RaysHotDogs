using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Widget;
using RaysHotDogs.Core.Service;
using RaysHotDogs.Core.Model;

namespace RaysHotDogs.Fragments
{
    public class BaseFragment : Fragment
    {
        protected ListView listView;
        protected HotDogDataService hotDogDataService;
        protected List<HotDog> hotDogs;

        public BaseFragment()
        {
            hotDogDataService = new HotDogDataService();
        }

        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;
        }
        protected void FindViews()
        {
            listView = this.View.FindViewById<ListView>(Resource.Id.hotDogListView);
        }

        protected void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var hotDog = hotDogs[e.Position];

            var intent = new Intent();
            intent.SetClass(this.Activity, typeof(HotDogDetailActivity));
            intent.PutExtra("selectedHotDogId", hotDog.Id);

            StartActivityForResult(intent, 100);
        }
    }
}