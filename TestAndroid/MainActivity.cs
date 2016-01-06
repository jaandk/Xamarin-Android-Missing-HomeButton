using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Java.Lang;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace TestAndroid
{
    [Activity(Label = "TestAndroid")]
    public class MainActivity : AppCompatActivity
    {
        private int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resourcetheme
            SetContentView(Resource.Layout.tablayout);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            setupViewPager(viewPager);

            var tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(viewPager);

        }

        private void setupViewPager(ViewPager viewPager)
        {
            ViewPageAdapter adapter = new ViewPageAdapter(SupportFragmentManager);
            adapter.addFragment(new Fragment1(), "ONE");
            adapter.addFragment(new Fragment1(), "TWO");
            adapter.addFragment(new Fragment1(), "THREE");
            viewPager.Adapter=adapter;
        }
    }

    public class ViewPageAdapter : FragmentPagerAdapter
        {
            private List<Fragment> fragments = new List<Fragment>();
            private List<string> fragmentTitel = new List<string>();

            public ViewPageAdapter(IntPtr javaReference, JniHandleOwnership transfer)
                : base(javaReference, transfer)
            {
            }

            public ViewPageAdapter(FragmentManager fm)
                : base(fm)
            {

            }

            public override int Count
            {
                get { return fragments.Count; }
            }

            public override Fragment GetItem(int position)
            {
                return fragments[position];
            }

            public override ICharSequence GetPageTitleFormatted(int position)
            {
                return new Java.Lang.String(fragmentTitel[position]);
            }

            public void addFragment(Fragment fragment, string titel)
            {
                fragments.Add(fragment);
                fragmentTitel.Add(titel);
            }
        }

    
}

