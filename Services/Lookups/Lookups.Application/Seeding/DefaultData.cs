using Domain;

namespace Lookups.Application.Seeding
{
    public static class DefaultData
    {
        public static List<Lookup> GetDefaultLookups()
        {
            return new List<Lookup>
            {
                                new Lookup
                {
                    Name = "Roles", NameAr = "الأدوار", InternalCode = "Roles", InternalRef = null, IsActive = true
                },
                new Lookup
                {
                    Name = "Super Admin", NameAr = "المشرف العام", InternalCode = "ROLE_SUPER_ADMIN",
                    InternalRef = "Roles", IsActive = true
                },
                new Lookup
                {
                    Name = "Region Manager", NameAr = "مدير الإقليم", InternalCode = "ROLE_REGION_MANAGER",
                    InternalRef = "Roles", IsActive = true
                },
                new Lookup
                {
                    Name = "Branch Administrator", NameAr = "مدير الفرع", InternalCode = "ROLE_BRANCH_ADMIN",
                    InternalRef = "Roles", IsActive = true
                },
                new Lookup
                {
                    Name = "Content Creator", NameAr = "محرر المحتوى", InternalCode = "ROLE_CONTENT_CREATOR",
                    InternalRef = "Roles", IsActive = true
                },
                new Lookup
                {
                    Name = "Customer Service Representative", NameAr = "ممثل خدمة العملاء", InternalCode = "ROLE_CSR",
                    InternalRef = "Roles", IsActive = true
                },

                new Lookup
                {
                    Name = "Contract Types", NameAr = "أنواع العقود", InternalCode = "Contract_Types",
                    InternalRef = null, IsActive = true
                },
                new Lookup
                {
                    Name = "Long-Term Contract", NameAr = "عقد طويل الأجل", InternalCode = "CONTRACT_LONG_TERM",
                    InternalRef = "Contract_Types", IsActive = true
                },
                new Lookup
                {
                    Name = "Short-Term Contract", NameAr = "عقد قصير الأجل", InternalCode = "CONTRACT_SHORT_TERM",
                    InternalRef = "Contract_Types", IsActive = true
                },
                new Lookup
                {
                    Name = "Subscription-Based Contract", NameAr = "عقد اشتراك", InternalCode = "CONTRACT_SUBSCRIPTION",
                    InternalRef = "Contract_Types", IsActive = true
                }, 

                new Lookup
                {
                    Name = "Pricing Categories", NameAr = "فئات التسعير", InternalCode = "Pricing_Categories",
                    InternalRef = null, IsActive = true
                },
                new Lookup
                {
                    Name = "Base Price", NameAr = "السعر الأساسي", InternalCode = "PRICING_BASE",
                    InternalRef = "Pricing_Categories", IsActive = true
                },
                new Lookup
                {
                    Name = "Discounts", NameAr = "الخصومات", InternalCode = "PRICING_DISCOUNTS",
                    InternalRef = "Pricing_Categories", IsActive = true
                },
                new Lookup
                {
                    Name = "Seasonal Offers", NameAr = "العروض الموسمية", InternalCode = "PRICING_SEASONAL",
                    InternalRef = "Pricing_Categories", IsActive = true
                },

                                new Lookup
                {
                    Name = "Packages", NameAr = "الباقات", InternalCode = "Packages", InternalRef = null,
                    IsActive = true
                },
                new Lookup
                {
                    Name = "Main Package", NameAr = "الباقة الرئيسية", InternalCode = "PKG_MAIN",
                    InternalRef = "Packages", IsActive = true
                },
                new Lookup
                {
                    Name = "Virtual Office Package", NameAr = "باقات المكتب الافتراضي",
                    InternalCode = "PKG_VIRTUAL_OFFICE", InternalRef = "Packages", IsActive = true
                },
                new Lookup
                {
                    Name = "Meeting Room Package", NameAr = "باقات قاعات الاجتماعات", InternalCode = "PKG_MEETING_ROOM",
                    InternalRef = "Packages", IsActive = true
                },
                new Lookup
                {
                    Name = "LMS Package", NameAr = "باقات نظام إدارة التعلم", InternalCode = "PKG_LMS",
                    InternalRef = "Packages", IsActive = true
                },

                                new Lookup
                {
                    Name = "Workspace Categories", NameAr = "فئات مساحات العمل", InternalCode = "Workspace_Categories",
                    InternalRef = null, IsActive = true
                },
                new Lookup
                {
                    Name = "Co-Working Space", NameAr = "مساحات العمل المشترك", InternalCode = "WORKSPACE_COWORKING",
                    InternalRef = "Workspace_Categories", IsActive = true
                },
                new Lookup
                {
                    Name = "Private Office", NameAr = "المكاتب الخاصة", InternalCode = "WORKSPACE_PRIVATE",
                    InternalRef = "Workspace_Categories", IsActive = true
                },
                new Lookup
                {
                    Name = "Meeting Room", NameAr = "غرفة الاجتماعات", InternalCode = "WORKSPACE_MEETING",
                    InternalRef = "Workspace_Categories", IsActive = true
                },

                                new Lookup
                {
                    Name = "Events", NameAr = "الفعاليات", InternalCode = "Events", InternalRef = null, IsActive = true
                },
                new Lookup
                {
                    Name = "Networking Event", NameAr = "فعاليات الشبكات", InternalCode = "EVENT_NETWORKING",
                    InternalRef = "Events", IsActive = true
                },
                new Lookup
                {
                    Name = "Training Workshop", NameAr = "ورش العمل التدريبية", InternalCode = "EVENT_WORKSHOP",
                    InternalRef = "Events", IsActive = true
                },
                new Lookup
                {
                    Name = "Product Launch", NameAr = "إطلاق المنتجات", InternalCode = "EVENT_PRODUCT_LAUNCH",
                    InternalRef = "Events", IsActive = true
                },

                                new Lookup
                {
                    Name = "Supporting Services", NameAr = "الخدمات الداعمة", InternalCode = "Supporting_Services",
                    InternalRef = null, IsActive = true
                },
                new Lookup
                {
                    Name = "IT Support", NameAr = "الدعم الفني", InternalCode = "SERVICE_IT_SUPPORT",
                    InternalRef = "Supporting_Services", IsActive = true
                },
                new Lookup
                {
                    Name = "Legal Consultation", NameAr = "الاستشارات القانونية", InternalCode = "SERVICE_LEGAL",
                    InternalRef = "Supporting_Services", IsActive = true
                },
                new Lookup
                {
                    Name = "Business Coaching", NameAr = "التوجيه التجاري", InternalCode = "SERVICE_COACHING",
                    InternalRef = "Supporting_Services", IsActive = true
                },

                                new Lookup
                {
                    Name = "Content Types", NameAr = "أنواع المحتوى", InternalCode = "Content_Types",
                    InternalRef = null, IsActive = true
                },
                new Lookup
                {
                    Name = "News", NameAr = "الأخبار", InternalCode = "CONTENT_NEWS", InternalRef = "Content_Types",
                    IsActive = true
                },
                new Lookup
                {
                    Name = "Blogs", NameAr = "المدونات", InternalCode = "CONTENT_BLOGS", InternalRef = "Content_Types",
                    IsActive = true
                },
                new Lookup
                {
                    Name = "Success Stories", NameAr = "قصص النجاح", InternalCode = "CONTENT_SUCCESS_STORIES",
                    InternalRef = "Content_Types", IsActive = true
                },

                                new Lookup
                {
                    Name = "Notifications", NameAr = "الإشعارات", InternalCode = "Notifications", InternalRef = null,
                    IsActive = true
                },
                new Lookup
                {
                    Name = "SMS Notifications", NameAr = "إشعارات الرسائل القصيرة", InternalCode = "NOTIFICATION_SMS",
                    InternalRef = "Notifications", IsActive = true
                },
                new Lookup
                {
                    Name = "Email Notifications", NameAr = "إشعارات البريد الإلكتروني",
                    InternalCode = "NOTIFICATION_EMAIL", InternalRef = "Notifications", IsActive = true
                },
                new Lookup
                {
                    Name = "System Alerts", NameAr = "تنبيهات النظام", InternalCode = "NOTIFICATION_ALERTS",
                    InternalRef = "Notifications", IsActive = true
                },

                                new Lookup
                {
                    Name = "Branch Category", NameAr = "تصنيف الفروع", InternalCode = "BRANCH_CATEGORY",
                    InternalRef = null, IsActive = true
                },
                new Lookup
                {
                    Name = "Branch Category 1", NameAr = "التصنيف الأول", InternalCode = "BranchCategoryOne",
                    InternalRef = "BRANCH_CATEGORY", IsActive = true
                },
                new Lookup
                {
                    Name = "Branch Category 2", NameAr = "التصنيف الثاني", InternalCode = "BranchCategory2",
                    InternalRef = "BRANCH_CATEGORY", IsActive = true
                },

                                new Lookup
                {
                    Name = "Branch Component", NameAr = "مكونات الفرع", InternalCode = "Branch_Component",
                    InternalRef = null, IsActive = true
                },
                new Lookup
                {
                    Name = "First Component", NameAr = "المكون الأول", InternalCode = "First_Component",
                    InternalRef = "Branch_Component", IsActive = true
                },
                new Lookup
                {
                    Name = "Second Component", NameAr = "المكون الثاني", InternalCode = "Second_Component",
                    InternalRef = "Branch_Component", IsActive = true
                },
                new Lookup
                {
                    Name = "Third Component", NameAr = "المكون الثالث", InternalCode = "Third_Component",
                    InternalRef = "Branch_Component", IsActive = true
                }

            };
        }
        public static List<Lookup> GetSaudiArabiaGovernorates()
        {
            var list = new List<Lookup>();

            list.Add(new Lookup
            {
                Name = "All Saudi Governorates",
                NameAr = "جميع محافظات السعودية",
                Description = "All Governorates in the Kingdom of Saudi Arabia",
                DescriptionAr = "جميع المحافظات في المملكة العربية السعودية",
                InternalCode = "KSA_GOV",
                InternalRef = null,
                IsActive = true
            });


            list.AddRange(new[]
{
        new Lookup { Name = "Riyadh",            NameAr = "الرياض",            InternalCode = "GOV_SA_RIYADH",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Ad Diriyah",        NameAr = "الدرعية",           InternalCode = "GOV_SA_DIRIYAH",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Kharj",          NameAr = "الخرج",             InternalCode = "GOV_SA_KHARJ",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Ad Dilam",          NameAr = "الدلم",            InternalCode = "GOV_SA_DILAM",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Ad Dawadimi",       NameAr = "الدوادمي",          InternalCode = "GOV_SA_DAWADIMI",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Majma'ah",       NameAr = "المجمعة",          InternalCode = "GOV_SA_MAJMAAH",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Quway'iyah",     NameAr = "القويعية",          InternalCode = "GOV_SA_QUWAYIYAH",    InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Wadi Ad Dawasir",   NameAr = "وادي الدواسر",      InternalCode = "GOV_SA_WADIDAWASIR",  InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Aflaj",          NameAr = "الأفلاج",           InternalCode = "GOV_SA_AFLAJ",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Az Zulfi",          NameAr = "الزلفي",            InternalCode = "GOV_SA_ZULFI",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Ghāt",           NameAr = "الغاط",             InternalCode = "GOV_SA_GHAT",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Shaqra",            NameAr = "شقراء",             InternalCode = "GOV_SA_SHAQRA",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Hawtat Bani Tamim", NameAr = "حوطة بني تميم",     InternalCode = "GOV_SA_HAWTATBANIT",  InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Hariq",          NameAr = "الحريق",            InternalCode = "GOV_SA_HARIQ",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Afif",              NameAr = "عفيف",              InternalCode = "GOV_SA_AFIF",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Murat",             NameAr = "مرات",              InternalCode = "GOV_SA_MURAT",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Thadiq",            NameAr = "ثادق",              InternalCode = "GOV_SA_THADIQ",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Duruma",            NameAr = "ضرما",              InternalCode = "GOV_SA_DURUMA",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Muzahimiyah",    NameAr = "المزاحمية",         InternalCode = "GOV_SA_MUZAHIMIYAH",  InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Rumah",             NameAr = "رماح",              InternalCode = "GOV_SA_RUMAH",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "As Sulayyil",       NameAr = "السليل",            InternalCode = "GOV_SA_SULAYYIL",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Huraymila",         NameAr = "حريملاء",           InternalCode = "GOV_SA_HURAYMILA",    InternalRef = "KSA_GOV", IsActive = true },
    });

            list.AddRange(new[]
{
        new Lookup { Name = "Jeddah",           NameAr = "جدة",             InternalCode = "GOV_SA_JEDDAH",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Makkah",           NameAr = "مكة المكرمة",     InternalCode = "GOV_SA_MAKKAH",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "At Taif",          NameAr = "الطائف",          InternalCode = "GOV_SA_TAIF",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Rabigh",           NameAr = "رابغ",            InternalCode = "GOV_SA_RABIGH",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Khulais",          NameAr = "خليص",            InternalCode = "GOV_SA_KHULAIS",    InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Kamil",         NameAr = "الكامل",          InternalCode = "GOV_SA_KAMIL",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Lith",          NameAr = "الليث",           InternalCode = "GOV_SA_LITH",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Qunfudhah",     NameAr = "القنفذة",         InternalCode = "GOV_SA_QUNFUDHAH",  InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Jumum",         NameAr = "الجموم",          InternalCode = "GOV_SA_JUMUM",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Bahrah",           NameAr = "بحرة",            InternalCode = "GOV_SA_BAHRah",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Turubah",         NameAr = "تربة",            InternalCode = "GOV_SA_TURUBAH",    InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Ranyah",           NameAr = "رنية",            InternalCode = "GOV_SA_RANYAH",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Khurmah",       NameAr = "الخرمة",          InternalCode = "GOV_SA_KHURMAH",    InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Muwayh",        NameAr = "المويه",          InternalCode = "GOV_SA_MUWAYH",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Maysan",           NameAr = "ميسان",           InternalCode = "GOV_SA_MAYSAN",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Adham",            NameAr = "أضم",             InternalCode = "GOV_SA_ADHAM",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Ardiyat",       NameAr = "العرضيات",        InternalCode = "GOV_SA_ARDIYAT",    InternalRef = "KSA_GOV", IsActive = true },
    });

            list.AddRange(new[]
{
        new Lookup { Name = "Al Madinah",       NameAr = "المدينة المنورة",   InternalCode = "GOV_SA_MADINAH",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Yanbu",            NameAr = "ينبع",              InternalCode = "GOV_SA_YANBU",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al 'Ula",          NameAr = "العلا",             InternalCode = "GOV_SA_ALULA",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Mahd Adh Dhahab",  NameAr = "مهد الذهب",         InternalCode = "GOV_SA_MAHD",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Hanakiyah",     NameAr = "الحناكية",          InternalCode = "GOV_SA_HANAKIYAH",    InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Badr",             NameAr = "بدر",               InternalCode = "GOV_SA_BADR",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Khaybar",          NameAr = "خيبر",              InternalCode = "GOV_SA_KHAYBAR",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al 'Iss",          NameAr = "العيص",             InternalCode = "GOV_SA_ALAYIS",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Wadi Al Fara'",    NameAr = "وادي الفرع",        InternalCode = "GOV_SA_WADIFARAA",    InternalRef = "KSA_GOV", IsActive = true },
    });

            list.AddRange(new[]
{
        new Lookup { Name = "Buraydah",         NameAr = "بريدة",         InternalCode = "GOV_SA_BURAYDAH",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Unaizah",          NameAr = "عنيزة",         InternalCode = "GOV_SA_UNAIZAH",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Ar Rass",          NameAr = "الرس",          InternalCode = "GOV_SA_RASS",          InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Midhnab",       NameAr = "المذنب",        InternalCode = "GOV_SA_MIDHNAB",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Bukayriyah",    NameAr = "البكيرية",       InternalCode = "GOV_SA_BUKAYRIYAH",    InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Badayea",       NameAr = "البدائع",        InternalCode = "GOV_SA_BADAYEA",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Asyah",         NameAr = "الأسياح",        InternalCode = "GOV_SA_ASYAH",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "An Nabhaniah",     NameAr = "النبهانية",      InternalCode = "GOV_SA_NABHANIAH",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Riyadh Al Khabra", NameAr = "رياض الخبراء",    InternalCode = "GOV_SA_RIYADHKHABRA", InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Uyun Al Jawa",     NameAr = "عيون الجواء",     InternalCode = "GOV_SA_UYUNJAWA",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Ash Shimasiyah",   NameAr = "الشماسية",        InternalCode = "GOV_SA_SHIMASIYAH",    InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Aqlat As Suqur",   NameAr = "عقلة الصقور",     InternalCode = "GOV_SA_AQLATSUQUR",    InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Dariyah",          NameAr = "ضرية",           InternalCode = "GOV_SA_DARIYAH",       InternalRef = "KSA_GOV", IsActive = true },
    });

            list.AddRange(new[]
{
        new Lookup { Name = "Ad Dammam",        NameAr = "الدمام",          InternalCode = "GOV_SA_DAMMAM",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Ahsa",          NameAr = "الأحساء",         InternalCode = "GOV_SA_AHSA",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Hafar Al Batin",   NameAr = "حفر الباطن",      InternalCode = "GOV_SA_HAFAR",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Jubail",        NameAr = "الجبيل",          InternalCode = "GOV_SA_JUBAIL",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Qatif",         NameAr = "القطيف",          InternalCode = "GOV_SA_QATIF",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Khobar",        NameAr = "الخبر",           InternalCode = "GOV_SA_KHOBAR",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Khafji",        NameAr = "الخفجي",          InternalCode = "GOV_SA_KHAFJI",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Qaryat Al Ulya",   NameAr = "قرية العليا",      InternalCode = "GOV_SA_QARYAULYA",    InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "An Nu'ayriyah",    NameAr = "النعيرية",        InternalCode = "GOV_SA_NUAYRIYAH",    InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Buqayq",           NameAr = "بقيق",            InternalCode = "GOV_SA_BUQAYQ",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Ras Tanura",       NameAr = "رأس تنورة",        InternalCode = "GOV_SA_RASTANURA",    InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al 'Udayd",        NameAr = "العديد",          InternalCode = "GOV_SA_UDAYD",        InternalRef = "KSA_GOV", IsActive = true },
    });

            list.AddRange(new[]
{
        new Lookup { Name = "Abha",             NameAr = "أبها",             InternalCode = "GOV_SA_ABHA",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Khamis Mushayt",   NameAr = "خميس مشيط",        InternalCode = "GOV_SA_KHAMIS",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Ahad Rifidah",     NameAr = "أحد رفيدة",         InternalCode = "GOV_SA_AHADRFIDA",    InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Zahran Al Janub",  NameAr = "ظهران الجنوب",     InternalCode = "GOV_SA_ZAHRANJANUB",  InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Sarat Abidah",     NameAr = "سراة عبيدة",        InternalCode = "GOV_SA_SARATABIDAH",  InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "An Namas",         NameAr = "النماص",           InternalCode = "GOV_SA_NAMAS",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Rijal Almaa",      NameAr = "رجال ألمع",        InternalCode = "GOV_SA_RIJALALMAA",   InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Muhayil",          NameAr = "محايل",            InternalCode = "GOV_SA_MUHAYIL",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Bisha",            NameAr = "بيشة",            InternalCode = "GOV_SA_BISHA",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Bark",          NameAr = "البرك",            InternalCode = "GOV_SA_ALBARK",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Barq",             NameAr = "بارق",             InternalCode = "GOV_SA_BARQ",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Majardah",      NameAr = "المجاردة",         InternalCode = "GOV_SA_MAJARDAH",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Balqarn",          NameAr = "بلقرن",            InternalCode = "GOV_SA_BALQARN",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Tathlith",         NameAr = "تثليث",            InternalCode = "GOV_SA_TATHLITH",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Tanumah",          NameAr = "تنومة",            InternalCode = "GOV_SA_TANUMAH",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Tareeb",           NameAr = "طريب",             InternalCode = "GOV_SA_TAREEB",       InternalRef = "KSA_GOV", IsActive = true },
    });

            list.AddRange(new[]
{
        new Lookup { Name = "Tabuk",            NameAr = "تبوك",             InternalCode = "GOV_SA_TABUK",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Tayma",            NameAr = "تيماء",            InternalCode = "GOV_SA_TAYMA",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Duba",             NameAr = "ضباء",             InternalCode = "GOV_SA_DUBA",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Wajh",          NameAr = "الوجه",            InternalCode = "GOV_SA_WAJH",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Haql",             NameAr = "حقل",             InternalCode = "GOV_SA_HAQL",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Umluj",            NameAr = "أملج",             InternalCode = "GOV_SA_UMLUJ",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Bada'",         NameAr = "البدع",            InternalCode = "GOV_SA_ALBADA",       InternalRef = "KSA_GOV", IsActive = true },
    });

            list.AddRange(new[]
{
        new Lookup { Name = "Hail",            NameAr = "حائل",             InternalCode = "GOV_SA_HAIL",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Baq'a",           NameAr = "بقعاء",            InternalCode = "GOV_SA_BAQA",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Ash Shannan",     NameAr = "الشنان",           InternalCode = "GOV_SA_SHANNAN",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Hait",         NameAr = "الحائط",           InternalCode = "GOV_SA_HAIT",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Ghazalah",     NameAr = "الغزالة",          InternalCode = "GOV_SA_GHAZALAH",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Moqaq",           NameAr = "موقق",             InternalCode = "GOV_SA_MOQAQ",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "As Sulaymi",      NameAr = "السليمي",          InternalCode = "GOV_SA_SULAYMI",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Ash Shamli",      NameAr = "الشملي",           InternalCode = "GOV_SA_SHAMLI",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Samira",          NameAr = "سميراء",           InternalCode = "GOV_SA_SAMIRA",       InternalRef = "KSA_GOV", IsActive = true },
    });

            list.AddRange(new[]
{
        new Lookup { Name = "Arar",             NameAr = "عرعر",             InternalCode = "GOV_SA_ARAR",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Rafha",            NameAr = "رفحاء",            InternalCode = "GOV_SA_RAFHA",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Turaif",           NameAr = "طريف",             InternalCode = "GOV_SA_TURAIF",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al 'Uwayqilah",    NameAr = "العويقيلة",        InternalCode = "GOV_SA_UWAYQILAH",    InternalRef = "KSA_GOV", IsActive = true },
    });

            list.AddRange(new[]
{
        new Lookup { Name = "Jazan",            NameAr = "جازان",            InternalCode = "GOV_SA_JAZAN",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Sabya",            NameAr = "صبيا",             InternalCode = "GOV_SA_SABYA",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Abu 'Arish",       NameAr = "أبو عريش",         InternalCode = "GOV_SA_ABUARISH",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Samitah",         NameAr = "صامطة",            InternalCode = "GOV_SA_SAMITA",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Bish",            NameAr = "بيش",              InternalCode = "GOV_SA_BISH",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al 'Ardhah",       NameAr = "العارضة",          InternalCode = "GOV_SA_ARDHAH",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Damad",           NameAr = "ضمد",              InternalCode = "GOV_SA_DAMAD",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Ad Darb",         NameAr = "الدرب",            InternalCode = "GOV_SA_DARB",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Harath",       NameAr = "الحرث",            InternalCode = "GOV_SA_HARATH",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Farasan",         NameAr = "فرسان",            InternalCode = "GOV_SA_FARASAN",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al 'Aidabi",       NameAr = "العيدابي",         InternalCode = "GOV_SA_AIDABI",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Ahad Al Masarihah", NameAr = "أحد المسارحة",   InternalCode = "GOV_SA_AHADMASARHA",  InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Ar Rayth",        NameAr = "الريث",            InternalCode = "GOV_SA_RAYTH",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Harub",           NameAr = "هروب",             InternalCode = "GOV_SA_HARUB",        InternalRef = "KSA_GOV", IsActive = true },
    });

            list.AddRange(new[]
{
        new Lookup { Name = "Najran",           NameAr = "نجران",            InternalCode = "GOV_SA_NAJRAN",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Sharurah",         NameAr = "شرورة",            InternalCode = "GOV_SA_SHARURAH",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Hubuna",           NameAr = "حبونا",            InternalCode = "GOV_SA_HUBUNA",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Badr Al Janoub",   NameAr = "بدر الجنوب",       InternalCode = "GOV_SA_BADRALJANOUB", InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Yadamah",          NameAr = "يدمة",             InternalCode = "GOV_SA_YADAMAH",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Thar",             NameAr = "ثار",             InternalCode = "GOV_SA_THAR",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Khubash",          NameAr = "خباش",            InternalCode = "GOV_SA_KHUBASH",      InternalRef = "KSA_GOV", IsActive = true },
    });

            list.AddRange(new[]
{
        new Lookup { Name = "Al Baha",          NameAr = "الباحة",          InternalCode = "GOV_SA_ALBAHA",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Baljurashi",       NameAr = "بلجرشي",          InternalCode = "GOV_SA_BALJURASHI",   InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Mandaq",        NameAr = "المندق",          InternalCode = "GOV_SA_MANDAQ",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Mukhwah",       NameAr = "المخواة",         InternalCode = "GOV_SA_MUKHWAH",      InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Qilwah",           NameAr = "قلوة",            InternalCode = "GOV_SA_QILWAH",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al 'Aqiq",         NameAr = "العقيق",          InternalCode = "GOV_SA_AQIQA",        InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Qara",          NameAr = "القرى",           InternalCode = "GOV_SA_QARA",         InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Ghamid Az Zinad",  NameAr = "غامد الزناد",     InternalCode = "GOV_SA_GHAMIDZINAD",  InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Hajrah",        NameAr = "الحجرة",          InternalCode = "GOV_SA_HAJRAH",       InternalRef = "KSA_GOV", IsActive = true },
    });

            list.AddRange(new[]
{
        new Lookup { Name = "Sakaka",           NameAr = "سكاكا",            InternalCode = "GOV_SA_SAKAKA",       InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Al Qurayyat",      NameAr = "القريات",          InternalCode = "GOV_SA_QURAYYAT",     InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Dumat Al Jandal",  NameAr = "دومة الجندل",      InternalCode = "GOV_SA_DUMATJANDAL",  InternalRef = "KSA_GOV", IsActive = true },
        new Lookup { Name = "Tubarjal",         NameAr = "طبرجل",            InternalCode = "GOV_SA_TUBARJAL",     InternalRef = "KSA_GOV", IsActive = true },
    });

            return list;
        }
        public static List<Lookup> GetFacilityLookups()
        {
            var list = new List<Lookup>();


            list.Add(new Lookup
            {
                Name = "Facility Category",
                NameAr = "تصنيف المنشأة",
                Description = "Main reference for all facility categories",
                DescriptionAr = "مرجع رئيسي لجميع تصنيفات المنشآت",
                InternalCode = "FACILITY_CATEGORY",
                InternalRef = null,
                IsActive = true
            });

            list.AddRange(new[]
{
        new Lookup
        {
            Name = "Hospital",
            NameAr = "مستشفى",
            Description = "Hospital category",
            DescriptionAr = "تصنيف مستشفيات",
            InternalCode = "FACILITY_CATEGORY_HOSPITAL",
            InternalRef = "FACILITY_CATEGORY",
            IsActive = true
        },
        new Lookup
        {
            Name = "Pharmacy",
            NameAr = "صيدلية",
            Description = "Pharmacy category",
            DescriptionAr = "تصنيف صيدليات",
            InternalCode = "FACILITY_CATEGORY_PHARMACY",
            InternalRef = "FACILITY_CATEGORY",
            IsActive = true
        },
        new Lookup
        {
            Name = "Hotel",
            NameAr = "فندق",
            Description = "Hotel category",
            DescriptionAr = "تصنيف فنادق",
            InternalCode = "FACILITY_CATEGORY_HOTEL",
            InternalRef = "FACILITY_CATEGORY",
            IsActive = true
        },
        new Lookup
        {
            Name = "Restaurant",
            NameAr = "مطعم",
            Description = "Restaurant category",
            DescriptionAr = "تصنيف مطاعم",
            InternalCode = "FACILITY_CATEGORY_RESTAURANT",
            InternalRef = "FACILITY_CATEGORY",
            IsActive = true
        }
            });



            list.Add(new Lookup
            {
                Name = "Facility Type",
                NameAr = "نوع المنشأة",
                Description = "Main reference for all facility types",
                DescriptionAr = "مرجع رئيسي لجميع أنواع المنشآت",
                InternalCode = "FACILITY_TYPE",
                InternalRef = null,
                IsActive = true
            });

            list.AddRange(new[]
{
        new Lookup
        {
            Name = "Private",
            NameAr = "خاص",
            Description = "Private facility type",
            DescriptionAr = "منشأة خاصة",
            InternalCode = "FACILITY_TYPE_PRIVATE",
            InternalRef = "FACILITY_TYPE",
            IsActive = true
        },
        new Lookup
        {
            Name = "Public",
            NameAr = "عام",
            Description = "Public facility type",
            DescriptionAr = "منشأة حكومية / عامة",
            InternalCode = "FACILITY_TYPE_PUBLIC",
            InternalRef = "FACILITY_TYPE",
            IsActive = true
        },
        new Lookup
        {
            Name = "Charity",
            NameAr = "خيري",
            Description = "Charity / Non-Profit facility type",
            DescriptionAr = "منشأة خيرية / غير ربحية",
            InternalCode = "FACILITY_TYPE_CHARITY",
            InternalRef = "FACILITY_TYPE",
            IsActive = true
        }
            });


            list.Add(new Lookup
            {
                Name = "Facility Destination",
                NameAr = "وجهة المنشأة",
                Description = "Main reference for facility destination",
                DescriptionAr = "مرجع رئيسي لوجهة / غرض المنشأة",
                InternalCode = "FACILITY_DESTINATION",
                InternalRef = null,
                IsActive = true
            });

            list.AddRange(new[]
{
        new Lookup
        {
            Name = "Local",
            NameAr = "محلي",
            Description = "Local destination",
            DescriptionAr = "غرض / وجهة محلية",
            InternalCode = "FACILITY_DESTINATION_LOCAL",
            InternalRef = "FACILITY_DESTINATION",
            IsActive = true
        },
        new Lookup
        {
            Name = "Touristic",
            NameAr = "سياحي",
            Description = "Touristic destination",
            DescriptionAr = "غرض / وجهة سياحية",
            InternalCode = "FACILITY_DESTINATION_TOURISTIC",
            InternalRef = "FACILITY_DESTINATION",
            IsActive = true
        }
            });



            list.Add(new Lookup
            {
                Name = "Facility Pricing Unit",
                NameAr = "وحدة التسعير للمنشأة",
                Description = "Main reference for facility pricing units",
                DescriptionAr = "مرجع رئيسي لوحدات التسعير",
                InternalCode = "FACILITY_PRICING_UNIT",
                InternalRef = null,
                IsActive = true
            });

            list.AddRange(new[]
{
        new Lookup
        {
            Name = "Per Hour",
            NameAr = "لكل ساعة",
            Description = "Pricing per hour",
            DescriptionAr = "التسعير لكل ساعة",
            InternalCode = "FACILITY_PRICING_UNIT_HOUR",
            InternalRef = "FACILITY_PRICING_UNIT",
            IsActive = true
        },
        new Lookup
        {
            Name = "Per Day",
            NameAr = "لكل يوم",
            Description = "Pricing per day",
            DescriptionAr = "التسعير لكل يوم",
            InternalCode = "FACILITY_PRICING_UNIT_DAY",
            InternalRef = "FACILITY_PRICING_UNIT",
            IsActive = true
        },
        new Lookup
        {
            Name = "Per Month",
            NameAr = "لكل شهر",
            Description = "Pricing per month",
            DescriptionAr = "التسعير لكل شهر",
            InternalCode = "FACILITY_PRICING_UNIT_MONTH",
            InternalRef = "FACILITY_PRICING_UNIT",
            IsActive = true
        },
        new Lookup
        {
            Name = "Fixed",
            NameAr = "سعر ثابت",
            Description = "Fixed rate / one-time",
            DescriptionAr = "تسعير ثابت / مرة واحدة",
            InternalCode = "FACILITY_PRICING_UNIT_FIXED",
            InternalRef = "FACILITY_PRICING_UNIT",
            IsActive = true
        }
            });



            list.Add(new Lookup
            {
                Name = "Facility Subscription",
                NameAr = "الاشتراك الخاص بالمنشأة",
                Description = "Main reference for facility subscriptions",
                DescriptionAr = "مرجع رئيسي لأنواع الاشتراكات",
                InternalCode = "FACILITY_SUBSCRIPTION",
                InternalRef = null,
                IsActive = true
            });

            list.AddRange(new[]
{
        new Lookup
        {
            Name = "Monthly",
            NameAr = "شهري",
            Description = "Monthly subscription",
            DescriptionAr = "اشتراك شهري",
            InternalCode = "FACILITY_SUBSCRIPTION_MONTHLY",
            InternalRef = "FACILITY_SUBSCRIPTION",
            IsActive = true
        },
        new Lookup
        {
            Name = "Quarterly",
            NameAr = "ربع سنوي",
            Description = "Quarterly subscription",
            DescriptionAr = "اشتراك ربع سنوي",
            InternalCode = "FACILITY_SUBSCRIPTION_QUARTERLY",
            InternalRef = "FACILITY_SUBSCRIPTION",
            IsActive = true
        },
        new Lookup
        {
            Name = "Yearly",
            NameAr = "سنوي",
            Description = "Yearly subscription",
            DescriptionAr = "اشتراك سنوي",
            InternalCode = "FACILITY_SUBSCRIPTION_YEARLY",
            InternalRef = "FACILITY_SUBSCRIPTION",
            IsActive = true
        }
            });



            list.Add(new Lookup
            {
                Name = "Facility Basic Contract",
                NameAr = "نوع العقد الأساسي",
                Description = "Main reference for facility basic contracts",
                DescriptionAr = "مرجع رئيسي لعقود المنشأة الأساسية",
                InternalCode = "FACILITY_BASIC_CONTRACT",
                InternalRef = null,
                IsActive = true
            });

            list.AddRange(new[]
{
        new Lookup
        {
            Name = "StandardContract",
            NameAr = "عقد قياسي",
            Description = "Standard contract for facilities",
            DescriptionAr = "عقد أساسي قياسي للمنشأة",
            InternalCode = "FACILITY_BASIC_CONTRACT_STANDARD",
            InternalRef = "FACILITY_BASIC_CONTRACT",
            IsActive = true
        },
        new Lookup
        {
            Name = "CustomContract",
            NameAr = "عقد مخصص",
            Description = "Custom contract tailored to facility",
            DescriptionAr = "عقد مخصص وفق احتياج المنشأة",
            InternalCode = "FACILITY_BASIC_CONTRACT_CUSTOM",
            InternalRef = "FACILITY_BASIC_CONTRACT",
            IsActive = true
        }
            });

            return list;
        }
    }
}
