
using Identity.Infrastructure.Models;

using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.Seeding
{
    public static class DefaultData
    {
        public static List<ApplicationUser> GetDefaultUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            return new List<ApplicationUser>
        {
            new ApplicationUser
            {
                UserName = "SuperAdmin",
                NormalizedUserName = "SUPERADMIN",
                Email = "SuperAdmin@example.com",
                NormalizedEmail = "SUPERADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "SuperAdmin@123"),
                SecurityStamp = Guid.NewGuid().ToString(),
                UserNameAr = "المستخدم الرئيسي"
            },
            new ApplicationUser {
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "Admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = Guid.NewGuid().ToString(),
                UserNameAr = "المدير العام"
            },
            new ApplicationUser {
                UserName = "Guest",
                NormalizedUserName = "GUEST",
                Email = "Guest@example.com",
                NormalizedEmail = "GUEST@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Guest@123"),
                SecurityStamp = Guid.NewGuid().ToString(),
                UserNameAr = "زائر"
            },
            new ApplicationUser {
                UserName = "User",
                NormalizedUserName = "User",
                Email = "User@example.com",
                NormalizedEmail = "User@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "User@123"),
                SecurityStamp = Guid.NewGuid().ToString(),
                UserNameAr = "مستخدم"
            }
        };
        }

        public static List<ApplicationRole> GetDefaultRoles()
        {
            return new List<ApplicationRole>
                {
                    new ApplicationRole {  Name = "SuperAdmin", NormalizedName = "SUPERADMIN" , RoleNameAr = "المستخدم الرئيسي"},
                    new ApplicationRole {  Name = "Admin", NormalizedName = "ADMIN" , RoleNameAr = "المدير" },
                    new ApplicationRole {  Name = "User", NormalizedName = "USER" , RoleNameAr = "مستخدم" },
                    new ApplicationRole {  Name = "Guest", NormalizedName = "Guest" , RoleNameAr = "زائر"},
                };
        }

        public static List<Permission> GetDefaultPermissions()
        {
            var defaultPermissions = new List<Permission>
    {
        // أمثلة على الصلاحيات الموجودة لديك مسبقًا
        new Permission
        {
            Name = "CreateUser",
            Description = "Can Create users",
            NameAr = "اضافة مستخدم",
            DescriptionAr = "امكانية اضافة مستخدمين"
        },
        new Permission
        {
            Name = "DeleteUser",
            Description = "Can Delete users",
            NameAr = "حذف مستخدم",
            DescriptionAr = "امكانية حذف مستخدمين"
        },
        new Permission
        {
            Name = "EditUser",
            Description = "Can Edit users",
            NameAr = "تعديل مستخدم",
            DescriptionAr = "امكانية تعديل مستخدمين"
        },
        new Permission
        {
            Name = "ViewUser",
            Description = "Can View users",
            NameAr = "عرض بيانات مستخدم",
            DescriptionAr = "امكانية عرض بيانات مستخدمين"
        }
    };

            // نضيف هنا الصلاحيات الخاصة بالجدول (جادة30)

            var jada30Permissions = new List<Permission>
    {
        new Permission
        {
            Name = "ViewMediaContent",
            Description = "Can view Jada30 media content",
            NameAr = "تصفح المحتوى الإعلامي لجادة 30",
            DescriptionAr = "إمكانية عرض / تصفح المحتوى الإعلامي لجادة 30"
        },
        new Permission
        {
            Name = "ViewFacilities",
            Description = "Can view facilities in all branches",
            NameAr = "تصفح معلومات مختلف المرافق بكل الفروع",
            DescriptionAr = "إمكانية عرض معلومات المرافق بجميع الفروع"
        },
        new Permission
        {
            Name = "ViewBasicPackages",
            Description = "Can view basic packages in Jada30 branches",
            NameAr = "تصفح الباقات الأساسية بفروع جادة30",
            DescriptionAr = "إمكانية عرض الباقات الأساسية بفروع جادة 30"
        },
        new Permission
        {
            Name = "ViewLongTermContracts",
            Description = "Can view the long-term contracts associated with a package",
            NameAr = "تصفح العقود الطويلة المصاحبة للباقة",
            DescriptionAr = "إمكانية عرض العقود الطويلة المصاحبة للباقة"
        },
        new Permission
        {
            Name = "ViewAvailablePackagesAndContracts",
            Description = "Can view available packages and contracts for subscription",
            NameAr = "تصفح الباقات والعقود المتاحة للاشتراك في المرافق",
            DescriptionAr = "عرض جميع الباقات والعقود المتاحة للمستخدم للاشتراك"
        },
        new Permission
        {
            Name = "ViewEventsAndSubscribe",
            Description = "Can view branch events (and subscribe if allowed)",
            NameAr = "تصفح فعاليات الفروع",
            DescriptionAr = "إمكانية عرض فعاليات الفروع ومعرفة المعلومات اللازمة عنها (ومعرفة إمكانية الاشتراك)"
        },
        new Permission
        {
            Name = "RatePlatformPage",
            Description = "Can rate any page in the platform",
            NameAr = "تقييم إحدى صفحات المنصة",
            DescriptionAr = "إمكانية تقييم صفحة معينة"
        },
        new Permission
        {
            Name = "ViewFAQ",
            Description = "Can view the Frequently Asked Questions",
            NameAr = "تصفح الأسئلة الشائعة",
            DescriptionAr = "عرض قائمة الأسئلة الشائعة"
        },
        new Permission
        {
            Name = "ContactUs",
            Description = "Can send a message via 'Contact Us' page",
            NameAr = "تواصل معنا",
            DescriptionAr = "إمكانية إرسال رسالة عبر صفحة اتصل بنا"
        },
        new Permission
        {
            Name = "RequestBranchTour",
            Description = "Can request a scheduled tour in the branch",
            NameAr = "طلب جدولة جولة بالفرع",
            DescriptionAr = "إمكانية إرسال طلب لجولة تعريفية بالفرع"
        },
        new Permission
        {
            Name = "RegisterAccount",
            Description = "Can register a new account",
            NameAr = "تسجيل الحساب وتعريف المستفيد",
            DescriptionAr = "إمكانية قيام الزائر بتسجيل حساب جديد"
        },

        // من هنا فأنت تبدأ بصلاحيات "المستفيد" (User)
        new Permission
        {
            Name = "Login",
            Description = "Can login",
            NameAr = "تسجيل الدخول",
            DescriptionAr = "إمكانية تسجيل الدخول للمستفيد"
        },
        new Permission
        {
            Name = "ChangePassword",
            Description = "Can change password",
            NameAr = "تغيير كلمة المرور",
            DescriptionAr = "إمكانية تغيير كلمة المرور للمستفيد"
        },
        new Permission
        {
            Name = "ForgotPassword",
            Description = "Can request a forgot password form",
            NameAr = "هل نسيت كلمة المرور؟",
            DescriptionAr = "إمكانية طلب نموذج إعادة تعيين كلمة المرور"
        },
        new Permission
        {
            Name = "SubscribeBasicPackage",
            Description = "Can subscribe to one of the basic packages",
            NameAr = "الاشتراك في إحدى الباقات الأساسية",
            DescriptionAr = "إمكانية الاشتراك في إحدى الباقات الأساسية"
        },
        new Permission
        {
            Name = "SubscribeExtendedPackage",
            Description = "Can subscribe to any extended (شاملة) package",
            NameAr = "الاشتراك في إحدى الباقات الشاملة",
            DescriptionAr = "إمكانية الاشتراك في باقة شاملة"
        },
        new Permission
        {
            Name = "AddFacility",
            Description = "Can add a facility to user’s subscription",
            NameAr = "إضافة مرافق لاشتراك المستفيد",
            DescriptionAr = "إمكانية إضافة مرافق لاشتراك المستفيد"
        },
        new Permission
        {
            Name = "SubscribeVirtualOffice",
            Description = "Can subscribe to a virtual office package",
            NameAr = "الاشتراك في باقة المكتب الافتراضي",
            DescriptionAr = "إمكانية الاشتراك في باقة المكتب الافتراضي"
        },
        new Permission
        {
            Name = "SubscribeFeasibilityPlatform",
            Description = "Can subscribe to the feasibility study platform in Jada30",
            NameAr = "اشتراك في منصة دراسة الجدوى",
            DescriptionAr = "إمكانية الاشتراك في منصة دراسة الجدوى بجادة30"
        },
        new Permission
        {
            Name = "SubscribeTools",
            Description = "Can subscribe to tools (tests)",
            NameAr = "الاشتراك في الأدوات (الاختبرات)",
            DescriptionAr = "إمكانية الاشتراك في أدوات / اختبارات المنصة"
        },
        new Permission
        {
            Name = "SubscribePerks",
            Description = "Can subscribe to Perks",
            NameAr = "الاشتراك في الممكنات (Perks)",
            DescriptionAr = "إمكانية الاشتراك في الممكنات (Perks)"
        },
        new Permission
        {
            Name = "SubscribeSupportServices",
            Description = "Can subscribe to supporting services",
            NameAr = "الاشترام في الخجمات الداعمة",
            DescriptionAr = "إمكانية الاشتراك في الخدمات الداعمة"
        },
        new Permission
        {
            Name = "ManageCart",
            Description = "Can manage shopping cart",
            NameAr = "إدارة عربة التسوق",
            DescriptionAr = "عرض أو تعديل عربة التسوق"
        },
        new Permission
        {
            Name = "CompleteProfileBeforePayment",
            Description = "Can view/add/edit personal data before payment",
            NameAr = "إستكمال البيانات الشخصية قبل الدفع",
            DescriptionAr = "عرض وإضافة وتعديل البيانات الشخصية قبل الدفع"
        },
        new Permission
        {
            Name = "PaymentGateway",
            Description = "Can access payment gateway",
            NameAr = "بوابة الدفع",
            DescriptionAr = "إمكانية الوصول لبوابة الدفع"
        },
        new Permission
        {
            Name = "ViewActiveSubscriptions",
            Description = "Can view and renew active subscriptions",
            NameAr = "الاشتراكات المفعلة",
            DescriptionAr = "إمكانية عرض الاشتراكات المفعّلة وتجديدها أو ترقيتها"
        },
        new Permission
        {
            Name = "ViewFacilitiesToReserve",
            Description = "Can view available facilities for reservation",
            NameAr = "المرافق المتاحة للحجز",
            DescriptionAr = "عرض المرافق المتاحة لحجزها"
        },
        new Permission
        {
            Name = "ViewPackageConsumption",
            Description = "Can view subscription usage/consumption",
            NameAr = "استهلاك الباقة",
            DescriptionAr = "عرض إحصائيات وبيانات استهلاك الباقة"
        },
        new Permission
        {
            Name = "ViewBookingsTimeline",
            Description = "Can view booking timeline for user subscriptions",
            NameAr = "الجدول الزمني للحجوزات",
            DescriptionAr = "عرض الجدول الزمني للحجوزات الخاصة بالمستفيد"
        },
        new Permission
        {
            Name = "ViewBranchEvents",
            Description = "Can view branch events and subscribe if needed",
            NameAr = "فعاليات الفروع",
            DescriptionAr = "إمكانية عرض الفعاليات والاشتراك فيها"
        },
        new Permission
        {
            Name = "ViewOrEditUserData",
            Description = "Can view or edit user’s own data and subscriptions",
            NameAr = "بيانات تسجيل المستفيد واشتراكاته",
            DescriptionAr = "عرض أو تعديل بيانات تسجيل المستفيد واشتراكاته"
        },
        new Permission
        {
            Name = "RateJada30Services",
            Description = "Can send feedback/rating about Jada30 services",
            NameAr = "تقييم خدمات جادة 30",
            DescriptionAr = "إمكانية إرسال تقييم لخدمات جادة 30"
        }
    };

            // نجمع الصلاحيات في قائمة واحدة:
            defaultPermissions.AddRange(jada30Permissions);
            return defaultPermissions;
        }


        public static List<RolePermission> GetDefaultRolePermissions()
        {
            return new List<RolePermission>
            {
                new RolePermission { RoleId = 1, PermissionId = 1 },
                new RolePermission { RoleId = 1, PermissionId = 2 },
                new RolePermission { RoleId = 1, PermissionId = 3 },
                new RolePermission { RoleId = 1, PermissionId = 4 },
                new RolePermission { RoleId = 2, PermissionId = 4 }
            };
        }
    }

    public class PermissionData
    {
        // الدور
        public string RoleName { get; set; }

        // الصلاحية
        public string PermissionName { get; set; }

        //الصلاحية الأساسية
        public string Permissions { get; set; }

    }
}
