package md5c65a0de53b6c3ae6ca419c690fa87304;


public class MySearchBarRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.SearchBarRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ShelfLifeApp.Droid.MySearchBarRenderer, ShelfLifeApp.Droid", MySearchBarRenderer.class, __md_methods);
	}


	public MySearchBarRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MySearchBarRenderer.class)
			mono.android.TypeManager.Activate ("ShelfLifeApp.Droid.MySearchBarRenderer, ShelfLifeApp.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public MySearchBarRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MySearchBarRenderer.class)
			mono.android.TypeManager.Activate ("ShelfLifeApp.Droid.MySearchBarRenderer, ShelfLifeApp.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public MySearchBarRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MySearchBarRenderer.class)
			mono.android.TypeManager.Activate ("ShelfLifeApp.Droid.MySearchBarRenderer, ShelfLifeApp.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
