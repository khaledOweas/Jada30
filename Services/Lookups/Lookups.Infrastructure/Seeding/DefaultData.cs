using Lookups.Domain.Entities;

namespace Lookups.Infrastructure.Seeding
{
    public static class DefaultData
    {
        public static List<Lookup> GetDefaultLookups()
        {
            return new List<Lookup>
    {
        // Parent Lookup: Roles
        new Lookup { Name = "Roles", NameAr = "الأدوار", InternalCode = "Roles", InternalRef = null, IsActive = true },
        new Lookup { Name = "Super Admin", NameAr = "المشرف العام", InternalCode = "ROLE_SUPER_ADMIN", InternalRef = "Roles", IsActive = true },
        new Lookup { Name = "Region Manager", NameAr = "مدير الإقليم", InternalCode = "ROLE_REGION_MANAGER", InternalRef = "Roles", IsActive = true },
        new Lookup { Name = "Branch Administrator", NameAr = "مدير الفرع", InternalCode = "ROLE_BRANCH_ADMIN", InternalRef = "Roles", IsActive = true },
        new Lookup { Name = "Content Creator", NameAr = "محرر المحتوى", InternalCode = "ROLE_CONTENT_CREATOR", InternalRef = "Roles", IsActive = true },
        new Lookup { Name = "Customer Service Representative", NameAr = "ممثل خدمة العملاء", InternalCode = "ROLE_CSR", InternalRef = "Roles", IsActive = true },

        // Parent Lookup: Contract Types
        new Lookup { Name = "Contract Types", NameAr = "أنواع العقود", InternalCode = "Contract_Types", InternalRef = null, IsActive = true },
        new Lookup { Name = "Long-Term Contract", NameAr = "عقد طويل الأجل", InternalCode = "CONTRACT_LONG_TERM", InternalRef = "Contract_Types", IsActive = true },
        new Lookup { Name = "Short-Term Contract", NameAr = "عقد قصير الأجل", InternalCode = "CONTRACT_SHORT_TERM", InternalRef = "Contract_Types", IsActive = true },
        new Lookup { Name = "Subscription-Based Contract", NameAr = "عقد اشتراك", InternalCode = "CONTRACT_SUBSCRIPTION", InternalRef = "Contract_Types", IsActive = true },

        // Parent Lookup: Pricing Categories
        new Lookup { Name = "Pricing Categories", NameAr = "فئات التسعير", InternalCode = "Pricing_Categories", InternalRef = null, IsActive = true },
        new Lookup { Name = "Base Price", NameAr = "السعر الأساسي", InternalCode = "PRICING_BASE", InternalRef = "Pricing_Categories", IsActive = true },
        new Lookup { Name = "Discounts", NameAr = "الخصومات", InternalCode = "PRICING_DISCOUNTS", InternalRef = "Pricing_Categories", IsActive = true },
        new Lookup { Name = "Seasonal Offers", NameAr = "العروض الموسمية", InternalCode = "PRICING_SEASONAL", InternalRef = "Pricing_Categories", IsActive = true },
        new Lookup { Name = "Promotions", NameAr = "العروض الترويجية", InternalCode = "PRICING_PROMOTIONS", InternalRef = "Pricing_Categories", IsActive = true },

        // Parent Lookup: Packages
        new Lookup { Name = "Packages", NameAr = "الباقات", InternalCode = "Packages", InternalRef = null, IsActive = true },
        new Lookup { Name = "Main Package", NameAr = "الباقة الرئيسية", InternalCode = "PKG_MAIN", InternalRef = "Packages", IsActive = true },
        new Lookup { Name = "Virtual Office Package", NameAr = "باقات المكتب الافتراضي", InternalCode = "PKG_VIRTUAL_OFFICE", InternalRef = "Packages", IsActive = true },
        new Lookup { Name = "Meeting Room Package", NameAr = "باقات قاعات الاجتماعات", InternalCode = "PKG_MEETING_ROOM", InternalRef = "Packages", IsActive = true },
        new Lookup { Name = "LMS Package", NameAr = "باقات نظام إدارة التعلم", InternalCode = "PKG_LMS", InternalRef = "Packages", IsActive = true },
        new Lookup { Name = "Premium Package", NameAr = "الباقة المميزة", InternalCode = "PKG_PREMIUM", InternalRef = "Packages", IsActive = true },

        // Parent Lookup: Branch Management
        new Lookup { Name = "Branch Management", NameAr = "إدارة الفروع", InternalCode = "Branch_Management", InternalRef = null, IsActive = true },
        new Lookup { Name = "Branch A", NameAr = "الفرع أ", InternalCode = "BRANCH_A", InternalRef = "Branch_Management", IsActive = true },
        new Lookup { Name = "Branch B", NameAr = "الفرع ب", InternalCode = "BRANCH_B", InternalRef = "Branch_Management", IsActive = true },
        new Lookup { Name = "Branch C", NameAr = "الفرع ج", InternalCode = "BRANCH_C", InternalRef = "Branch_Management", IsActive = true },
        new Lookup { Name = "Branch D", NameAr = "الفرع د", InternalCode = "BRANCH_D", InternalRef = "Branch_Management", IsActive = true },

        // Parent Lookup: Administrative Areas
        new Lookup { Name = "Administrative Areas", NameAr = "المناطق الإدارية", InternalCode = "Admin_Areas", InternalRef = null, IsActive = true },
        new Lookup { Name = "North Region", NameAr = "المنطقة الشمالية", InternalCode = "NORTH_REGION", InternalRef = "Admin_Areas", IsActive = true },
        new Lookup { Name = "South Region", NameAr = "المنطقة الجنوبية", InternalCode = "SOUTH_REGION", InternalRef = "Admin_Areas", IsActive = true },
        new Lookup { Name = "East Region", NameAr = "المنطقة الشرقية", InternalCode = "EAST_REGION", InternalRef = "Admin_Areas", IsActive = true },
        new Lookup { Name = "West Region", NameAr = "المنطقة الغربية", InternalCode = "WEST_REGION", InternalRef = "Admin_Areas", IsActive = true },

        // Parent Lookup: Workspace Management
        new Lookup { Name = "Workspace Management", NameAr = "إدارة المرافق", InternalCode = "Workspace_Management", InternalRef = null, IsActive = true },
        new Lookup { Name = "Office", NameAr = "مكتب", InternalCode = "WORKSPACE_OFFICE", InternalRef = "Workspace_Management", IsActive = true },
        new Lookup { Name = "Meeting Room", NameAr = "غرفة اجتماعات", InternalCode = "WORKSPACE_MEETING_ROOM", InternalRef = "Workspace_Management", IsActive = true },
        new Lookup { Name = "Co-Working Space", NameAr = "مساحات العمل المشتركة", InternalCode = "WORKSPACE_COWORKING", InternalRef = "Workspace_Management", IsActive = true },
        new Lookup { Name = "Event Hall", NameAr = "قاعة الفعاليات", InternalCode = "WORKSPACE_EVENT_HALL", InternalRef = "Workspace_Management", IsActive = true },
        new Lookup { Name = "Private Office", NameAr = "مكتب خاص", InternalCode = "WORKSPACE_PRIVATE_OFFICE", InternalRef = "Workspace_Management", IsActive = true },

        // Parent Lookup: Content Management
        new Lookup { Name = "Content Management", NameAr = "إدارة المحتوى الإعلامي", InternalCode = "Content_Management", InternalRef = null, IsActive = true },
        new Lookup { Name = "News", NameAr = "الأخبار", InternalCode = "CONTENT_NEWS", InternalRef = "Content_Management", IsActive = true },
        new Lookup { Name = "Blogs", NameAr = "المدونات", InternalCode = "CONTENT_BLOGS", InternalRef = "Content_Management", IsActive = true },
        new Lookup { Name = "Success Stories", NameAr = "قصص النجاح", InternalCode = "CONTENT_SUCCESS_STORIES", InternalRef = "Content_Management", IsActive = true },
        new Lookup { Name = "Tutorials", NameAr = "الدروس التعليمية", InternalCode = "CONTENT_TUTORIALS", InternalRef = "Content_Management", IsActive = true },
        new Lookup { Name = "Media Gallery", NameAr = "معرض الوسائط", InternalCode = "CONTENT_MEDIA_GALLERY", InternalRef = "Content_Management", IsActive = true },

        // Parent Lookup: Event Management
        new Lookup { Name = "Event Management", NameAr = "إدارة الفعاليات", InternalCode = "Event_Management", InternalRef = null, IsActive = true },
        new Lookup { Name = "Networking Event", NameAr = "فعالية تواصل", InternalCode = "EVENT_NETWORKING", InternalRef = "Event_Management", IsActive = true },
        new Lookup { Name = "Workshop", NameAr = "ورشة عمل", InternalCode = "EVENT_WORKSHOP", InternalRef = "Event_Management", IsActive = true },
        new Lookup { Name = "Product Launch", NameAr = "إطلاق منتج", InternalCode = "EVENT_PRODUCT_LAUNCH", InternalRef = "Event_Management", IsActive = true },
        new Lookup { Name = "Charity Event", NameAr = "فعالية خيرية", InternalCode = "EVENT_CHARITY", InternalRef = "Event_Management", IsActive = true },

        // Parent Lookup: Supporting Services
        new Lookup { Name = "Supporting Services", NameAr = "الخدمات الداعمة", InternalCode = "Supporting_Services", InternalRef = null, IsActive = true },
        new Lookup { Name = "IT Support", NameAr = "الدعم التقني", InternalCode = "SERVICE_IT_SUPPORT", InternalRef = "Supporting_Services", IsActive = true },
        new Lookup { Name = "Legal Consultancy", NameAr = "الاستشارات القانونية", InternalCode = "SERVICE_LEGAL", InternalRef = "Supporting_Services", IsActive = true },
        new Lookup { Name = "Accounting Services", NameAr = "خدمات المحاسبة", InternalCode = "SERVICE_ACCOUNTING", InternalRef = "Supporting_Services", IsActive = true },
        new Lookup { Name = "Marketing Support", NameAr = "دعم التسويق", InternalCode = "SERVICE_MARKETING", InternalRef = "Supporting_Services", IsActive = true },

        // Parent Lookup: System Configuration
        new Lookup { Name = "System Configuration", NameAr = "إعدادات النظام", InternalCode = "System_Configuration", InternalRef = null, IsActive = true },
        new Lookup { Name = "Roles Management", NameAr = "إدارة الأدوار", InternalCode = "SYSTEM_ROLES", InternalRef = "System_Configuration", IsActive = true },
        new Lookup { Name = "Permissions Management", NameAr = "إدارة الصلاحيات", InternalCode = "SYSTEM_PERMISSIONS", InternalRef = "System_Configuration", IsActive = true },
        new Lookup { Name = "Settings Management", NameAr = "إدارة الإعدادات", InternalCode = "SYSTEM_SETTINGS", InternalRef = "System_Configuration", IsActive = true },
        new Lookup { Name = "User Management", NameAr = "إدارة المستخدمين", InternalCode = "SYSTEM_USERS", InternalRef = "System_Configuration", IsActive = true }
    };
        }


    }
}
