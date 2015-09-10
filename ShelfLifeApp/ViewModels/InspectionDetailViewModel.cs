using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using ShelfLifeApp.Models;

namespace ShelfLifeApp.ViewModels
{
	public class InspectionDetailViewModel : BaseViewModel
	{
		public InspectionDetailViewModel ()
		{
		}

		private static readonly object padLock = new object ();
		private static InspectionDetailViewModel _Instance = null;
		private List<Colors> _colorList = new List<Colors>();
		private List<Stage> _stageList = new List<Stage>();
		private List<Lenticel> _lenticelList = new List<Lenticel>();
		private List<Defect> _defectList = new List<Defect>();
		private int _color = -1;
		private int _stage = -1;
		private int _lenticel = -1;
		private int _defect = -1;
		private bool _cut;
		private string _comment;
		public static InspectionDetailViewModel Instance
		{
			get{
				if(_Instance == null){
					lock (padLock){
						if(_Instance == null){
							_Instance = new InspectionDetailViewModel ();

						}
					}
				}
				return _Instance;
			}

		}

		public int Colors
		{
			get{ return _color;}
			set{ 
				if(_color == value)
				{
					return;
				}
				_color = value;
				OnPropertyChanged ();
			}
		}

		public int Stage
		{
			get{ return _stage;}
			set{ 
				if(_stage == value)
				{
					return;
				}
				_stage = value;
				OnPropertyChanged ();
			}
		}

		public int Lenticel
		{
			get{ return _lenticel;}
			set{ 
				if(_lenticel == value)
				{
					return;
				}
				_lenticel = value;
				OnPropertyChanged ();
			}
		}

		public int Defect
		{
			get{ return _defect;}
			set{ 
				if(_defect == value)
				{
					return;
				}
				_defect = value;
				OnPropertyChanged ();
			}
		}

		public bool Cut
		{
			get{ return _cut;}
			set{ 
				if(_cut = value)
				{
					return;
				}
				_cut = value;
				OnPropertyChanged ();
			}
		}

		public string Comment
		{
			get{ return _comment;}
			set{ 
				if(value.Equals(_comment, StringComparison.Ordinal))
				{
					return;
				}
				_comment = value;
				OnPropertyChanged ();
			}
		}

		public List<Colors> GetColor()
		{
			_colorList.Add(new Colors(0,"Green 1"));
			_colorList.Add(new Colors(1,"Green 2"));
			_colorList.Add(new Colors(2,"Green 3"));
			_colorList.Add(new Colors(3,"Green 4"));
			_colorList.Add(new Colors(4,"Green 5"));
			return _colorList;
		}

		public List<Stage> GetStage()
		{
			_stageList.Add (new Stage(0,"1, 1"));
			_stageList.Add (new Stage(1,"2, 2, 2"));
			_stageList.Add (new Stage(2,"3, 3, 3"));
			_stageList.Add (new Stage(3,"4, 4, 4"));
			_stageList.Add (new Stage(4,"5, 5"));
			return _stageList;
		}

		public List<Lenticel> GetLenticel()
		{
			_lenticelList.Add (new Lenticel(0,"Lenticel 1"));
			_lenticelList.Add (new Lenticel(1,"Lenticel 2"));
			_lenticelList.Add (new Lenticel(2,"Lenticel 3"));
			_lenticelList.Add (new Lenticel(3,"Lenticel 4"));
			_lenticelList.Add (new Lenticel(4,"Lenticel 5"));
			_lenticelList.Add (new Lenticel(5,"Lenticel 6"));
			_lenticelList.Add (new Lenticel(6,"Lenticel 7"));
			_lenticelList.Add (new Lenticel(7,"Lenticel 8"));
			_lenticelList.Add (new Lenticel(8,"Lenticel 9"));
			_lenticelList.Add (new Lenticel(9,"Lenticel 10"));
			return _lenticelList;
		}

		public List<Defect> GetDefect()
		{
			_defectList.Add (new Defect(0,"Defect 1"));
			return _defectList;
		}
			
	}
}

