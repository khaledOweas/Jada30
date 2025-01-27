using Domain;

namespace Lookups.Application.Seeding
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

        // Parent Lookup: Packages
        new Lookup { Name = "Packages", NameAr = "الباقات", InternalCode = "Packages", InternalRef = null, IsActive = true },
        new Lookup { Name = "Main Package", NameAr = "الباقة الرئيسية", InternalCode = "PKG_MAIN", InternalRef = "Packages", IsActive = true },
        new Lookup { Name = "Virtual Office Package", NameAr = "باقات المكتب الافتراضي", InternalCode = "PKG_VIRTUAL_OFFICE", InternalRef = "Packages", IsActive = true },
        new Lookup { Name = "Meeting Room Package", NameAr = "باقات قاعات الاجتماعات", InternalCode = "PKG_MEETING_ROOM", InternalRef = "Packages", IsActive = true },
        new Lookup { Name = "LMS Package", NameAr = "باقات نظام إدارة التعلم", InternalCode = "PKG_LMS", InternalRef = "Packages", IsActive = true },

        // Parent Lookup: Workspace Categories
        new Lookup { Name = "Workspace Categories", NameAr = "فئات مساحات العمل", InternalCode = "Workspace_Categories", InternalRef = null, IsActive = true },
        new Lookup { Name = "Co-Working Space", NameAr = "مساحات العمل المشترك", InternalCode = "WORKSPACE_COWORKING", InternalRef = "Workspace_Categories", IsActive = true },
        new Lookup { Name = "Private Office", NameAr = "المكاتب الخاصة", InternalCode = "WORKSPACE_PRIVATE", InternalRef = "Workspace_Categories", IsActive = true },
        new Lookup { Name = "Meeting Room", NameAr = "غرفة الاجتماعات", InternalCode = "WORKSPACE_MEETING", InternalRef = "Workspace_Categories", IsActive = true },

        // Parent Lookup: Events
        new Lookup { Name = "Events", NameAr = "الفعاليات", InternalCode = "Events", InternalRef = null, IsActive = true },
        new Lookup { Name = "Networking Event", NameAr = "فعاليات الشبكات", InternalCode = "EVENT_NETWORKING", InternalRef = "Events", IsActive = true },
        new Lookup { Name = "Training Workshop", NameAr = "ورش العمل التدريبية", InternalCode = "EVENT_WORKSHOP", InternalRef = "Events", IsActive = true },
        new Lookup { Name = "Product Launch", NameAr = "إطلاق المنتجات", InternalCode = "EVENT_PRODUCT_LAUNCH", InternalRef = "Events", IsActive = true },

        // Parent Lookup: Supporting Services
        new Lookup { Name = "Supporting Services", NameAr = "الخدمات الداعمة", InternalCode = "Supporting_Services", InternalRef = null, IsActive = true },
        new Lookup { Name = "IT Support", NameAr = "الدعم الفني", InternalCode = "SERVICE_IT_SUPPORT", InternalRef = "Supporting_Services", IsActive = true },
        new Lookup { Name = "Legal Consultation", NameAr = "الاستشارات القانونية", InternalCode = "SERVICE_LEGAL", InternalRef = "Supporting_Services", IsActive = true },
        new Lookup { Name = "Business Coaching", NameAr = "التوجيه التجاري", InternalCode = "SERVICE_COACHING", InternalRef = "Supporting_Services", IsActive = true },

        // Parent Lookup: Content Types
        new Lookup { Name = "Content Types", NameAr = "أنواع المحتوى", InternalCode = "Content_Types", InternalRef = null, IsActive = true },
        new Lookup { Name = "News", NameAr = "الأخبار", InternalCode = "CONTENT_NEWS", InternalRef = "Content_Types", IsActive = true },
        new Lookup { Name = "Blogs", NameAr = "المدونات", InternalCode = "CONTENT_BLOGS", InternalRef = "Content_Types", IsActive = true },
        new Lookup { Name = "Success Stories", NameAr = "قصص النجاح", InternalCode = "CONTENT_SUCCESS_STORIES", InternalRef = "Content_Types", IsActive = true },

        // Parent Lookup: Notifications
        new Lookup { Name = "Notifications", NameAr = "الإشعارات", InternalCode = "Notifications", InternalRef = null, IsActive = true },
        new Lookup { Name = "SMS Notifications", NameAr = "إشعارات الرسائل القصيرة", InternalCode = "NOTIFICATION_SMS", InternalRef = "Notifications", IsActive = true },
        new Lookup { Name = "Email Notifications", NameAr = "إشعارات البريد الإلكتروني", InternalCode = "NOTIFICATION_EMAIL", InternalRef = "Notifications", IsActive = true },
        new Lookup { Name = "System Alerts", NameAr = "تنبيهات النظام", InternalCode = "NOTIFICATION_ALERTS", InternalRef = "Notifications", IsActive = true }
    };
        }

    }
}
