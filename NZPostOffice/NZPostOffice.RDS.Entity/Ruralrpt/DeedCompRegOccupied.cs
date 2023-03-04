using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("one_nat", "_one_nat", "")]
    [MapInfo("two_nat", "_two_nat", "")]
    [MapInfo("three_nat", "_three_nat", "")]
    [MapInfo("four_nat", "_four_nat", "")]
    [MapInfo("five_nat", "_five_nat", "")]
    [MapInfo("six_nat", "_six_nat", "")]
    [MapInfo("total_nat", "_total_nat", "")]
    [MapInfo("one_ch", "_one_ch", "")]
    [MapInfo("two_ch", "_two_ch", "")]
    [MapInfo("three_ch", "_three_ch", "")]
    [MapInfo("four_ch", "_four_ch", "")]
    [MapInfo("five_ch", "_five_ch", "")]
    [MapInfo("six_ch", "_six_ch", "")]
    [MapInfo("total_ch", "_total_ch", "")]
    [MapInfo("one_dun", "_one_dun", "")]
    [MapInfo("two_dun", "_two_dun", "")]
    [MapInfo("three_dun", "_three_dun", "")]
    [MapInfo("four_dun", "_four_dun", "")]
    [MapInfo("five_dun", "_five_dun", "")]
    [MapInfo("six_dun", "_six_dun", "")]
    [MapInfo("total_dun", "_total_dun", "")]
    [MapInfo("one_ham", "_one_ham", "")]
    [MapInfo("two_ham", "_two_ham", "")]
    [MapInfo("three_ham", "_three_ham", "")]
    [MapInfo("four_ham", "_four_ham", "")]
    [MapInfo("five_ham", "_five_ham", "")]
    [MapInfo("six_ham", "_six_ham", "")]
    [MapInfo("total_ham", "_total_ham", "")]
    [MapInfo("one_p", "_one_p", "")]
    [MapInfo("two_p", "_two_p", "")]
    [MapInfo("three_p", "_three_p", "")]
    [MapInfo("four_p", "_four_p", "")]
    [MapInfo("five_p", "_five_p", "")]
    [MapInfo("six_p", "_six_p", "")]
    [MapInfo("total_p", "_total_p", "")]
    [MapInfo("one_rot", "_one_rot", "")]
    [MapInfo("two_rot", "_two_rot", "")]
    [MapInfo("three_rot", "_three_rot", "")]
    [MapInfo("four_rot", "_four_rot", "")]
    [MapInfo("five_rot", "_five_rot", "")]
    [MapInfo("six_rot", "_six_rot", "")]
    [MapInfo("total_rot", "_total_rot", "")]
    [MapInfo("one_w", "_one_w", "")]
    [MapInfo("two_w", "_two_w", "")]
    [MapInfo("three_w", "_three_w", "")]
    [MapInfo("four_w", "_four_w", "")]
    [MapInfo("five_w", "_five_w", "")]
    [MapInfo("six_w", "_six_w", "")]
    [MapInfo("total_w", "_total_w", "")]
    [MapInfo("pvt_one", "_pvt_one", "")]
    [MapInfo("pvt_two", "_pvt_two", "")]
    [MapInfo("pvt_three", "_pvt_three", "")]
    [MapInfo("pvt_four", "_pvt_four", "")]
    [MapInfo("pvt_five", "_pvt_five", "")]
    [MapInfo("pvt_six", "_pvt_six", "")]
    [System.Serializable()]

    public class DeedCompRegOccupied : Entity<DeedCompRegOccupied>
    {
        #region Business Methods
        [DBField()]
        private int? _one_nat;

        [DBField()]
        private int? _two_nat;

        [DBField()]
        private int? _three_nat;

        [DBField()]
        private int? _four_nat;

        [DBField()]
        private int? _five_nat;

        [DBField()]
        private int? _six_nat;

        [DBField()]
        private int? _total_nat;

        [DBField()]
        private int? _one_ch;

        [DBField()]
        private int? _two_ch;

        [DBField()]
        private int? _three_ch;

        [DBField()]
        private int? _four_ch;

        [DBField()]
        private int? _five_ch;

        [DBField()]
        private int? _six_ch;

        [DBField()]
        private int? _total_ch;

        [DBField()]
        private int? _one_dun;

        [DBField()]
        private int? _two_dun;

        [DBField()]
        private int? _three_dun;

        [DBField()]
        private int? _four_dun;

        [DBField()]
        private int? _five_dun;

        [DBField()]
        private int? _six_dun;

        [DBField()]
        private int? _total_dun;

        [DBField()]
        private int? _one_ham;

        [DBField()]
        private int? _two_ham;

        [DBField()]
        private int? _three_ham;

        [DBField()]
        private int? _four_ham;

        [DBField()]
        private int? _five_ham;

        [DBField()]
        private int? _six_ham;

        [DBField()]
        private int? _total_ham;

        [DBField()]
        private int? _one_p;

        [DBField()]
        private int? _two_p;

        [DBField()]
        private int? _three_p;

        [DBField()]
        private int? _four_p;

        [DBField()]
        private int? _five_p;

        [DBField()]
        private int? _six_p;

        [DBField()]
        private int? _total_p;

        [DBField()]
        private int? _one_rot;

        [DBField()]
        private int? _two_rot;

        [DBField()]
        private int? _three_rot;

        [DBField()]
        private int? _four_rot;

        [DBField()]
        private int? _five_rot;

        [DBField()]
        private int? _six_rot;

        [DBField()]
        private int? _total_rot;

        [DBField()]
        private int? _one_w;

        [DBField()]
        private int? _two_w;

        [DBField()]
        private int? _three_w;

        [DBField()]
        private int? _four_w;

        [DBField()]
        private int? _five_w;

        [DBField()]
        private int? _six_w;

        [DBField()]
        private int? _total_w;

        [DBField()]
        private int? _pvt_one;

        [DBField()]
        private int? _pvt_two;

        [DBField()]
        private int? _pvt_three;

        [DBField()]
        private int? _pvt_four;

        [DBField()]
        private int? _pvt_five;

        [DBField()]
        private int? _pvt_six;


        public virtual int? OneNat
        {
            get
            {
                CanReadProperty("OneNat", true);
                return _one_nat;
            }
            set
            {
                CanWriteProperty("OneNat", true);
                if (_one_nat != value)
                {
                    _one_nat = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REOneNat
        {
            get
            {
                return _one_nat;
            }
        }

        public virtual int? TwoNat
        {
            get
            {
                CanReadProperty("TwoNat", true);
                return _two_nat;
            }
            set
            {
                CanWriteProperty("TwoNat", true);
                if (_two_nat != value)
                {
                    _two_nat = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RETwoNat
        {
            get
            {
                return _two_nat;
            }
        }

        public virtual int? ThreeNat
        {
            get
            {
                CanReadProperty("ThreeNat", true);
                return _three_nat;
            }
            set
            {
                CanWriteProperty("ThreeNat", true);
                if (_three_nat != value)
                {
                    _three_nat = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REThreeNat
        {
            get
            {
                return _three_nat;
            }
        }

        public virtual int? FourNat
        {
            get
            {
                CanReadProperty("FourNat", true);
                return _four_nat;
            }
            set
            {
                CanWriteProperty("FourNat", true);
                if (_four_nat != value)
                {
                    _four_nat = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REFourNat
        {
            get
            {
                return _four_nat;
            }
        }

        public virtual int? FiveNat
        {
            get
            {
                CanReadProperty("FiveNat", true);
                return _five_nat;
            }
            set
            {
                CanWriteProperty("FiveNat", true);
                if (_five_nat != value)
                {
                    _five_nat = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REFiveNat
        {
            get
            {
                return _five_nat;
            }
        }

        public virtual int? SixNat
        {
            get
            {
                CanReadProperty("SixNat", true);
                return _six_nat;
            }
            set
            {
                CanWriteProperty("SixNat", true);
                if (_six_nat != value)
                {
                    _six_nat = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RESixNat
        {
            get
            {
                return _six_nat;
            }
        }

        public virtual int? TotalNat
        {
            get
            {
                CanReadProperty("TotalNat", true);
                return _total_nat;
            }
            set
            {
                CanWriteProperty("TotalNat", true);
                if (_total_nat != value)
                {
                    _total_nat = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RETotalNat
        {
            get
            {
                return _total_nat;
            }
        }

        public virtual int? OneCh
        {
            get
            {
                CanReadProperty("OneCh", true);
                return _one_ch;
            }
            set
            {
                CanWriteProperty("OneCh", true);
                if (_one_ch != value)
                {
                    _one_ch = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REOneCh
        {
            get
            {
                return OneCh;
            }
        }

        public virtual int? TwoCh
        {
            get
            {
                CanReadProperty("TwoCh", true);
                return _two_ch;
            }
            set
            {
                CanWriteProperty("TwoCh", true);
                if (_two_ch != value)
                {
                    _two_ch = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RETwoCh
        {
            get
            {
                return _two_ch;
            }
        }

        public virtual int? ThreeCh
        {
            get
            {
                CanReadProperty("ThreeCh", true);
                return _three_ch;
            }
            set
            {
                CanWriteProperty("ThreeCh", true);
                if (_three_ch != value)
                {
                    _three_ch = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REThreeCh
        {
            get
            {
                return _three_ch;
            }
        }

        public virtual int? FourCh
        {
            get
            {
                CanReadProperty("FourCh", true);
                return _four_ch;
            }
            set
            {
                CanWriteProperty("FourCh", true);
                if (_four_ch != value)
                {
                    _four_ch = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REFourCh
        {
            get
            {
                return _four_ch;
            }
        }

        public virtual int? FiveCh
        {
            get
            {
                CanReadProperty("FiveCh", true);
                return _five_ch;
            }
            set
            {
                CanWriteProperty("FiveCh", true);
                if (_five_ch != value)
                {
                    _five_ch = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REFiveCh
        {
            get
            {
                return _five_ch;
            }
        }

        public virtual int? SixCh
        {
            get
            {
                CanReadProperty("SixCh", true);
                return _six_ch;
            }
            set
            {
                CanWriteProperty("SixCh", true);
                if (_six_ch != value)
                {
                    _six_ch = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RESixCh
        {
            get
            {
                return _six_ch;
            }
        }

        public virtual int? TotalCh
        {
            get
            {
                CanReadProperty("TotalCh", true);
                return _total_ch;
            }
            set
            {
                CanWriteProperty("TotalCh", true);
                if (_total_ch != value)
                {
                    _total_ch = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RETotalCh
        {
            get
            {
                return _total_ch;
            }
        }

        public virtual int? OneDun
        {
            get
            {
                CanReadProperty("OneDun", true);
                return _one_dun;
            }
            set
            {
                CanWriteProperty("OneDun", true);
                if (_one_dun != value)
                {
                    _one_dun = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REOneDun
        {
            get
            {
                return _one_dun;
            }
        }

        public virtual int? TwoDun
        {
            get
            {
                CanReadProperty("TwoDun", true);
                return _two_dun;
            }
            set
            {
                CanWriteProperty("TwoDun", true);
                if (_two_dun != value)
                {
                    _two_dun = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RETwoDun
        {
            get
            {
                return _two_dun;
            }
        }

        public virtual int? ThreeDun
        {
            get
            {
                CanReadProperty("ThreeDun", true);
                return _three_dun;
            }
            set
            {
                CanWriteProperty("ThreeDun", true);
                if (_three_dun != value)
                {
                    _three_dun = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REThreeDun
        {
            get
            {
                return _three_dun;
            }
        }

        public virtual int? FourDun
        {
            get
            {
                CanReadProperty("FourDun", true);
                return _four_dun;
            }
            set
            {
                CanWriteProperty("FourDun", true);
                if (_four_dun != value)
                {
                    _four_dun = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REFourDun
        {
            get
            {
                return _four_dun;
            }
        }

        public virtual int? FiveDun
        {
            get
            {
                CanReadProperty("FiveDun", true);
                return _five_dun;
            }
            set
            {
                CanWriteProperty("FiveDun", true);
                if (_five_dun != value)
                {
                    _five_dun = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REFiveDun
        {
            get
            {
                return _five_dun;
            }
        }

        public virtual int? SixDun
        {
            get
            {
                CanReadProperty("SixDun", true);
                return _six_dun;
            }
            set
            {
                CanWriteProperty("SixDun", true);
                if (_six_dun != value)
                {
                    _six_dun = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RESixDun
        {
            get
            {
                return _six_dun;
            }
        }

        public virtual int? TotalDun
        {
            get
            {
                CanReadProperty("TotalDun", true);
                return _total_dun;
            }
            set
            {
                CanWriteProperty("TotalDun", true);
                if (_total_dun != value)
                {
                    _total_dun = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RETotalDun
        {
            get
            {
                return _total_dun;
            }
        }

        public virtual int? OneHam
        {
            get
            {
                CanReadProperty("OneHam", true);
                return _one_ham;
            }
            set
            {
                CanWriteProperty("OneHam", true);
                if (_one_ham != value)
                {
                    _one_ham = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REOneHam
        {
            get
            {
                return _one_ham;
            }
        }

        public virtual int? TwoHam
        {
            get
            {
                CanReadProperty("TwoHam", true);
                return _two_ham;
            }
            set
            {
                CanWriteProperty("TwoHam", true);
                if (_two_ham != value)
                {
                    _two_ham = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RETwoHam
        {
            get
            {
                return _two_ham;
            }
        }

        public virtual int? ThreeHam
        {
            get
            {
                CanReadProperty("ThreeHam", true);
                return _three_ham;
            }
            set
            {
                CanWriteProperty("ThreeHam", true);
                if (_three_ham != value)
                {
                    _three_ham = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REThreeHam
        {
            get
            {
                return _three_ham;
            }
        }

        public virtual int? FourHam
        {
            get
            {
                CanReadProperty("FourHam", true);
                return _four_ham;
            }
            set
            {
                CanWriteProperty("FourHam", true);
                if (_four_ham != value)
                {
                    _four_ham = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REFourHam
        {
            get
            {
                return _three_ham;
            }
        }

        public virtual int? FiveHam
        {
            get
            {
                CanReadProperty("FiveHam", true);
                return _five_ham;
            }
            set
            {
                CanWriteProperty("FiveHam", true);
                if (_five_ham != value)
                {
                    _five_ham = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REFiveHam
        {
            get
            {
                return _five_ham;
            }
        }

        public virtual int? SixHam
        {
            get
            {
                CanReadProperty("SixHam", true);
                return _six_ham;
            }
            set
            {
                CanWriteProperty("SixHam", true);
                if (_six_ham != value)
                {
                    _six_ham = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RESixHam
        {
            get
            {
                return _six_ham;
            }
        }

        public virtual int? TotalHam
        {
            get
            {
                CanReadProperty("TotalHam", true);
                return _total_ham;
            }
            set
            {
                CanWriteProperty("TotalHam", true);
                if (_total_ham != value)
                {
                    _total_ham = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RETotalHam
        {
            get
            {
                return _total_ham;
            }
        }

        public virtual int? OneP
        {
            get
            {
                CanReadProperty("OneP", true);
                return _one_p;
            }
            set
            {
                CanWriteProperty("OneP", true);
                if (_one_p != value)
                {
                    _one_p = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REOneP
        {
            get
            {
                return _one_p;
            }
        }

        public virtual int? TwoP
        {
            get
            {
                CanReadProperty("TwoP", true);
                return _two_p;
            }
            set
            {
                CanWriteProperty("TwoP", true);
                if (_two_p != value)
                {
                    _two_p = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RETwoP
        {
            get
            {
                return _two_p;
            }
        }

        public virtual int? ThreeP
        {
            get
            {
                CanReadProperty("ThreeP", true);
                return _three_p;
            }
            set
            {
                CanWriteProperty("ThreeP", true);
                if (_three_p != value)
                {
                    _three_p = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REThreeP
        {
            get
            {
                return _three_p;
            }
        }

        public virtual int? FourP
        {
            get
            {
                CanReadProperty("FourP", true);
                return _four_p;
            }
            set
            {
                CanWriteProperty("FourP", true);
                if (_four_p != value)
                {
                    _four_p = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REFourP
        {
            get
            {
                return _four_p;
            }
        }

        public virtual int? FiveP
        {
            get
            {
                CanReadProperty("FiveP", true);
                return _five_p;
            }
            set
            {
                CanWriteProperty("FiveP", true);
                if (_five_p != value)
                {
                    _five_p = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REFiveP
        {
            get
            {
                return _five_p;
            }
        }

        public virtual int? SixP
        {
            get
            {
                CanReadProperty("SixP", true);
                return _six_p;
            }
            set
            {
                CanWriteProperty("SixP", true);
                if (_six_p != value)
                {
                    _six_p = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RESixP
        {
            get
            {
                return _six_p;
            }
        }

        public virtual int? TotalP
        {
            get
            {
                CanReadProperty("TotalP", true);
                return _total_p;
            }
            set
            {
                CanWriteProperty("TotalP", true);
                if (_total_p != value)
                {
                    _total_p = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RETotalP
        {
            get
            {
                return _total_p;
            }
        }

        public virtual int? OneRot
        {
            get
            {
                CanReadProperty("OneRot", true);
                return _one_rot;
            }
            set
            {
                CanWriteProperty("OneRot", true);
                if (_one_rot != value)
                {
                    _one_rot = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REOneRot
        {
            get
            {
                return _one_rot;
            }
        }

        public virtual int? TwoRot
        {
            get
            {
                CanReadProperty("TwoRot", true);
                return _two_rot;
            }
            set
            {
                CanWriteProperty("TwoRot", true);
                if (_two_rot != value)
                {
                    _two_rot = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RETwoRot
        {
            get
            {
                return _two_rot;
            }
        }

        public virtual int? ThreeRot
        {
            get
            {
                CanReadProperty("ThreeRot", true);
                return _three_rot;
            }
            set
            {
                CanWriteProperty("ThreeRot", true);
                if (_three_rot != value)
                {
                    _three_rot = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REThreeRot
        {
            get
            {
                return _three_rot;
            }
        }

        public virtual int? FourRot
        {
            get
            {
                CanReadProperty("FourRot", true);
                return _four_rot;
            }
            set
            {
                CanWriteProperty("FourRot", true);
                if (_four_rot != value)
                {
                    _four_rot = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REFourRot
        {
            get
            {
                return _four_rot;
            }
        }

        public virtual int? FiveRot
        {
            get
            {
                CanReadProperty("FiveRot", true);
                return _five_rot;
            }
            set
            {
                CanWriteProperty("FiveRot", true);
                if (_five_rot != value)
                {
                    _five_rot = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REFiveRot
        {
            get
            {
                return _five_rot;
            }
        }

        public virtual int? SixRot
        {
            get
            {
                CanReadProperty("SixRot", true);
                return _six_rot;
            }
            set
            {
                CanWriteProperty("SixRot", true);
                if (_six_rot != value)
                {
                    _six_rot = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RESixRot
        {
            get
            {
                return _six_rot;
            }
        }

        public virtual int? TotalRot
        {
            get
            {
                CanReadProperty("TotalRot", true);
                return _total_rot;
            }
            set
            {
                CanWriteProperty("TotalRot", true);
                if (_total_rot != value)
                {
                    _total_rot = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RETotalRot
        {
            get
            {
                return _total_rot;
            }
        }

        public virtual int? OneW
        {
            get
            {
                CanReadProperty("OneW", true);
                return _one_w;
            }
            set
            {
                CanWriteProperty("OneW", true);
                if (_one_w != value)
                {
                    _one_w = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REOneW
        {
            get
            {
                return _one_w;
            }
        }

        public virtual int? TwoW
        {
            get
            {
                CanReadProperty("TwoW", true);
                return _two_w;
            }
            set
            {
                CanWriteProperty("TwoW", true);
                if (_two_w != value)
                {
                    _two_w = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RETwoW
        {
            get
            {
                return _two_w;
            }
        }

        public virtual int? ThreeW
        {
            get
            {
                CanReadProperty("ThreeW", true);
                return _three_w;
            }
            set
            {
                CanWriteProperty("ThreeW", true);
                if (_three_w != value)
                {
                    _three_w = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REThreeW
        {
            get
            {
                return _three_w;
            }
        }

        public virtual int? FourW
        {
            get
            {
                CanReadProperty("FourW", true);
                return _four_w;
            }
            set
            {
                CanWriteProperty("FourW", true);
                if (_four_w != value)
                {
                    _four_w = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REFourW
        {
            get
            {
                return _four_w;
            }
        }

        public virtual int? FiveW
        {
            get
            {
                CanReadProperty("FiveW", true);
                return _five_w;
            }
            set
            {
                CanWriteProperty("FiveW", true);
                if (_five_w != value)
                {
                    _five_w = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REFiveW
        {
            get
            {
                return _five_w;
            }
        }

        public virtual int? SixW
        {
            get
            {
                CanReadProperty("SixW", true);
                return _six_w;
            }
            set
            {
                CanWriteProperty("SixW", true);
                if (_six_w != value)
                {
                    _six_w = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RESixW
        {
            get
            {
                return _six_w;
            }
        }

        public virtual int? TotalW
        {
            get
            {
                CanReadProperty("TotalW", true);
                return _total_w;
            }
            set
            {
                CanWriteProperty("TotalW", true);
                if (_total_w != value)
                {
                    _total_w = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RETotalW
        {
            get
            {
                return _total_w;
            }
        }

        public virtual int? PvtOne
        {
            get
            {
                CanReadProperty("PvtOne", true);
                return _pvt_one;
            }
            set
            {
                CanWriteProperty("PvtOne", true);
                if (_pvt_one != value)
                {
                    _pvt_one = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REPvtOne
        {
            get
            {
                return _pvt_one;
            }
        }

        public virtual int? PvtTwo
        {
            get
            {
                CanReadProperty("PvtTwo", true);
                return _pvt_two;
            }
            set
            {
                CanWriteProperty("PvtTwo", true);
                if (_pvt_two != value)
                {
                    _pvt_two = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REPvtTwo
        {
            get
            {
                return _pvt_two;
            }
        }

        public virtual int? PvtThree
        {
            get
            {
                CanReadProperty("PvtThree", true);
                return _pvt_three;
            }
            set
            {
                CanWriteProperty("PvtThree", true);
                if (_pvt_three != value)
                {
                    _pvt_three = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REPvtThree
        {
            get
            {
                return _pvt_three;
            }
        }

        public virtual int? PvtFour
        {
            get
            {
                CanReadProperty("PvtFour", true);
                return _pvt_four;
            }
            set
            {
                CanWriteProperty("PvtFour", true);
                if (_pvt_four != value)
                {
                    _pvt_four = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REPvtFour
        {
            get
            {
                return _pvt_four;
            }
        }

        public virtual int? PvtFive
        {
            get
            {
                CanReadProperty("PvtFive", true);
                return _pvt_five;
            }
            set
            {
                CanWriteProperty("PvtFive", true);
                if (_pvt_five != value)
                {
                    _pvt_five = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REPvtFive
        {
            get
            {
                return _pvt_five;
            }
        }

        public virtual int? PvtSix
        {
            get
            {
                CanReadProperty("PvtSix", true);
                return _pvt_six;
            }
            set
            {
                CanWriteProperty("PvtSix", true);
                if (_pvt_six != value)
                {
                    _pvt_six = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REPvtSix
        {
            get
            {
                return _pvt_six;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_4]
        public virtual decimal? Compute4
        {
            get
            {
                CanReadProperty(true);
                return (_six_nat + _five_nat + _four_nat + _three_nat) / _total_nat;
            }
        }

        public decimal? RECompute4
        {
            get
            {
                return (decimal?)((_six_nat + _five_nat + _four_nat + _three_nat) / _total_nat);
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[compute_5]
        public virtual decimal? Compute5
        {
            get
            {
                CanReadProperty(true);
                return (_six_nat + _five_nat + _four_nat + _three_nat + _two_nat) / _total_nat;
            }
        }

        public decimal? RECompute5
        {
            get
            {
                return (decimal?)((_six_nat + _five_nat + _four_nat + _three_nat + _two_nat) / _total_nat);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[cust_3]
        public virtual int? Cust3
        {
            get
            {
                CanReadProperty(true);
                return _three_nat - _pvt_three;
            }
        }

        public int? RECust3
        {
            get
            {
                return (_three_nat - _pvt_three);
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[cust_2]
        public virtual int? Cust2
        {
            get
            {
                CanReadProperty(true);
                return _two_nat - _pvt_two;
            }
        }

        public int? RECust2
        {
            get
            {
                return (_two_nat - _pvt_two);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[cust_1]
        public virtual int? Cust1
        {
            get
            {
                CanReadProperty(true);
                return _one_nat - _pvt_one;
            }
        }

        public int? RECust1
        {
            get
            {
                return (_one_nat - _pvt_one);
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[compute_1]
        public virtual decimal? Compute1
        {
            get
            {
                CanReadProperty(true);
                return (_six_nat) / _total_nat;
            }
        }

        public decimal? RECompute1
        {
            get
            {
                return (decimal?)((_six_nat) / _total_nat);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_2]
        public virtual decimal? Compute2
        {
            get
            {
                CanReadProperty(true);
                return (_six_nat + _five_nat) / _total_nat;
            }
        }

        public decimal? RECompute2
        {
            get
            {
                return (decimal?)((_six_nat + _five_nat) / _total_nat);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_3]
        public virtual decimal? Compute3
        {
            get
            {
                CanReadProperty(true);
                return (_six_nat + _five_nat + _four_nat) / _total_nat;
            }
        }

        public decimal? RECompute3
        {
            get
            {
                return (decimal?)((_six_nat + _five_nat + _four_nat) / _total_nat);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[cust_6]
        public virtual int? Cust6
        {
            get
            {
                CanReadProperty(true);
                return _six_nat - _pvt_six;
            }
        }

        public int? RECust6
        {
            get
            {
                return (_six_nat - _pvt_six);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[cust_5]
        public virtual int? Cust5
        {
            get
            {
                CanReadProperty(true);
                return _five_nat - _pvt_five;
            }
        }

        public int? RECust5
        {
            get
            {
                return (_five_nat - _pvt_five);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[cust_4]
        public virtual int? Cust4
        {
            get
            {
                CanReadProperty(true);
                return _four_nat - _pvt_four;
            }
        }

        public int? RECust4
        {
            get
            {
                return (_four_nat - _pvt_four);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_7]
        public virtual int? Compute7
        {
            get
            {
                CanReadProperty(true);
                return _pvt_one + _pvt_two + _pvt_three + _pvt_four + _pvt_five + _pvt_six;
            }
        }

        public int? RECompute7
        {
            get
            {
                return (_pvt_one + _pvt_two + _pvt_three + _pvt_four + _pvt_five + _pvt_six);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[cust_tot]
        public virtual int? CustTot
        {
            get
            {
                CanReadProperty(true);
                return Cust6 + Cust5 + Cust4 + Cust3 + Cust2 + Cust1;
            }
        }

        public int? RECustTot
        {
            get
            {
                return (Cust6 + Cust5 + Cust4 + Cust3 + Cust2 + Cust1);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_6]
        public virtual DateTime? Compute6
        {
            get
            {
                CanReadProperty(true);
                return System.DateTime.Today;// today();
            }
        }

        public DateTime? RECompute6
        {
            get
            {
                return System.DateTime.Today;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[Custsub_5]
        public virtual int? Custsub5
        {
            get
            {
                CanReadProperty(true);
                return Cust4 + Cust3 + Cust2 + Cust1;
            }
        }

        public int? RECustsub5
        {
            get
            {
                return (Cust4 + Cust3 + Cust2 + Cust1);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[pvt_sub_five]
        public virtual int? PvtSubFive
        {
            get
            {
                CanReadProperty(true);
                return _pvt_one + _pvt_two + _pvt_three + _pvt_four;
            }
        }

        public int? REPvtSubFive
        {
            get
            {
                return (_pvt_one + _pvt_two + _pvt_three + _pvt_four);
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[compute_8]
        public virtual int? Compute8
        {
            get
            {
                CanReadProperty(true);
                return _one_nat + _two_nat + _three_nat + _four_nat;
            }
        }

        public int? RECompute8
        {
            get
            {
                return (_one_nat + _two_nat + _three_nat + _four_nat);
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[compute_9]
        public virtual decimal? Compute9
        {
            get
            {
                CanReadProperty(true);
                return (_one_nat + _two_nat + _three_nat + _four_nat) / _total_nat;
            }
        }

        public decimal? RECompute9
        {
            get
            {
                return (decimal?)((_one_nat + _two_nat + _three_nat + _four_nat) / _total_nat);
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[u5_nat]
        public virtual int? U5Nat
        {
            get
            {
                CanReadProperty(true);
                return _one_nat + _two_nat + _three_nat + _four_nat;
            }
        }

        public int? REU5Nat
        {
            get
            {
                return (_one_nat + _two_nat + _three_nat + _four_nat);
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[u5_ch]
        public virtual int? U5Ch
        {
            get
            {
                CanReadProperty(true);
                return _one_ch + _two_ch + _three_ch + _four_ch;
            }
        }

        public int? REU5Ch
        {
            get
            {
                return (_one_ch + _two_ch + _three_ch + _four_ch);
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[u5_dun]
        public virtual int? U5Dun
        {
            get
            {
                CanReadProperty(true);
                return _one_dun + _two_dun + _three_dun + _four_dun;
            }
        }

        public int? REU5Dun
        {
            get
            {
                return (_one_dun + _two_dun + _three_dun + _four_dun);
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[u5_ham]
        public virtual int? U5Ham
        {
            get
            {
                CanReadProperty(true);
                return _one_ham + _two_ham + _three_ham + _four_ham;
            }
        }

        public int? REU5Ham
        {
            get
            {
                return (_one_ham + _two_ham + _three_ham + _four_ham);
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[u5_p]
        public virtual int? U5P
        {
            get
            {
                CanReadProperty(true);
                return _one_p + _two_p + _three_p + _four_p;
            }
        }

        public int? REU5P
        {
            get
            {
                return (_one_p + _two_p + _three_p + _four_p);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[u5_rot]
        public virtual int? U5Rot
        {
            get
            {
                CanReadProperty(true);
                return _one_rot + _two_rot + _three_rot + _four_rot;
            }
        }

        public int? REU5Rot
        {
            get
            {
                return (_one_rot + _two_rot + _three_rot + _four_rot);
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[u5_w]
        public virtual int? U5W
        {
            get
            {
                CanReadProperty(true);
                return _one_w + _two_w + _three_w + _four_w;
            }
        }

        public int? REU5W
        {
            get
            {
                return (_one_w + _two_w + _three_w + _four_w);
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static DeedCompRegOccupied NewDeedCompRegOccupied()
        {
            return Create();
        }

        public static DeedCompRegOccupied[] GetAllDeedCompRegOccupied()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_deed_compliance_occupied";
                    cm.CommandTimeout = 120;
                    ParameterCollection pList = new ParameterCollection();

                    List<DeedCompRegOccupied> _list = new List<DeedCompRegOccupied>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            DeedCompRegOccupied instance = new DeedCompRegOccupied();
                            instance._one_nat = GetValueFromReader<int?>(dr, 0);
                            instance._two_nat = GetValueFromReader<int?>(dr, 1);
                            instance._three_nat = GetValueFromReader<int?>(dr, 2);
                            instance._four_nat = GetValueFromReader<int?>(dr, 3);
                            instance._five_nat = GetValueFromReader<int?>(dr, 4);
                            instance._six_nat = GetValueFromReader<int?>(dr, 5);
                            instance._total_nat = GetValueFromReader<int?>(dr, 6);
                            instance._one_ch = GetValueFromReader<int?>(dr, 7);
                            instance._two_ch = GetValueFromReader<int?>(dr, 8);
                            instance._three_ch = GetValueFromReader<int?>(dr, 9);
                            instance._four_ch = GetValueFromReader<int?>(dr, 10);
                            instance._five_ch = GetValueFromReader<int?>(dr, 11);
                            instance._six_ch = GetValueFromReader<int?>(dr, 12);
                            instance._total_ch = GetValueFromReader<int?>(dr, 13);
                            instance._one_dun = GetValueFromReader<int?>(dr, 14);
                            instance._two_dun = GetValueFromReader<int?>(dr, 15);
                            instance._three_dun = GetValueFromReader<int?>(dr, 16);
                            instance._four_dun = GetValueFromReader<int?>(dr, 17);
                            instance._five_dun = GetValueFromReader<int?>(dr, 18);
                            instance._six_dun = GetValueFromReader<int?>(dr, 19);
                            instance._total_dun = GetValueFromReader<int?>(dr, 20);
                            instance._one_ham = GetValueFromReader<int?>(dr, 21);
                            instance._two_ham = GetValueFromReader<int?>(dr, 22);
                            instance._three_ham = GetValueFromReader<int?>(dr, 23);
                            instance._four_ham = GetValueFromReader<int?>(dr, 24);
                            instance._five_ham = GetValueFromReader<int?>(dr, 25);
                            instance._six_ham = GetValueFromReader<int?>(dr, 26);
                            instance._total_ham = GetValueFromReader<int?>(dr, 27);
                            instance._one_p = GetValueFromReader<int?>(dr, 28);
                            instance._two_p = GetValueFromReader<int?>(dr, 29);
                            instance._three_p = GetValueFromReader<int?>(dr, 30);
                            instance._four_p = GetValueFromReader<int?>(dr, 31);
                            instance._five_p = GetValueFromReader<int?>(dr, 32);
                            instance._six_p = GetValueFromReader<int?>(dr, 33);
                            instance._total_p = GetValueFromReader<int?>(dr, 34);
                            instance._one_rot = GetValueFromReader<int?>(dr, 35);
                            instance._two_rot = GetValueFromReader<int?>(dr, 36);
                            instance._three_rot = GetValueFromReader<int?>(dr, 37);
                            instance._four_rot = GetValueFromReader<int?>(dr, 38);
                            instance._five_rot = GetValueFromReader<int?>(dr, 39);
                            instance._six_rot = GetValueFromReader<int?>(dr, 40);
                            instance._total_rot = GetValueFromReader<int?>(dr, 41);
                            instance._one_w = GetValueFromReader<int?>(dr, 42);
                            instance._two_w = GetValueFromReader<int?>(dr, 43);
                            instance._three_w = GetValueFromReader<int?>(dr, 44);
                            instance._four_w = GetValueFromReader<int?>(dr, 45);
                            instance._five_w = GetValueFromReader<int?>(dr, 46);
                            instance._six_w = GetValueFromReader<int?>(dr, 47);
                            instance._total_w = GetValueFromReader<int?>(dr, 48);
                            instance._pvt_one = GetValueFromReader<int?>(dr, 49);
                            instance._pvt_two = GetValueFromReader<int?>(dr, 50);
                            instance._pvt_three = GetValueFromReader<int?>(dr, 51);
                            instance._pvt_four = GetValueFromReader<int?>(dr, 52);
                            instance._pvt_five = GetValueFromReader<int?>(dr, 53);
                            instance._pvt_six = GetValueFromReader<int?>(dr, 54);
                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        list = _list.ToArray();
                    }
                }
            }
        }

        #endregion

        [ServerMethod()]
        private void CreateEntity()
        {
        }
    }
}
