package md5c65a0de53b6c3ae6ca419c690fa87304;


public class MyLabelRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.LabelRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ShelfLifeApp.Droid.MyLabelRenderer, ShelfLifeApp.Droid", MyLabelRenderer.class, __md_methods);
	}


	public MyLabelRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MyLabelRenderer.class)
			mono.android.TypeManager.Activate ("ShelfLifeApp.Droid.MyLabelRenderer, ShelfLifeApp.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public MyLabelRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MyLabelRenderer.class)
			mono.android.TypeManager.Activate ("ShelfLifeApp.Droid.MyLabelRenderer, ShelfLifeApp.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public MyLabelRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MyLabelRenderer.class)
			mono.android.TypeManager.Activate ("ShelfLifeApp.Droid.MyLabelRenderer, ShelfLifeApp.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
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
