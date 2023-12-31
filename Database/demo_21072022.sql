USE [axisid]
GO
/****** Object:  Table [dbo].[quotation_note]    Script Date: 2022-07-21 17:26:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[quotation_note](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quotation_Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_quotation_note] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_admin_login]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_admin_login](
	[a_id] [int] IDENTITY(1,1) NOT NULL,
	[a_email] [varchar](max) NULL,
	[a_password] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_admin_login] PRIMARY KEY CLUSTERED 
(
	[a_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_admin_role]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_admin_role](
	[ar_id] [int] IDENTITY(1,1) NOT NULL,
	[ar_name] [varchar](50) NULL,
	[ar_date] [date] NULL,
 CONSTRAINT [PK_tbl_admin_role] PRIMARY KEY CLUSTERED 
(
	[ar_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_admin_user]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_admin_user](
	[au_id] [int] IDENTITY(1,1) NOT NULL,
	[au_role] [varchar](50) NULL,
	[au_name] [varchar](50) NULL,
	[au_email] [varchar](max) NULL,
	[au_password] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_admin_user] PRIMARY KEY CLUSTERED 
(
	[au_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_bank]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_bank](
	[b_id] [int] IDENTITY(1,1) NOT NULL,
	[b_name] [varchar](50) NULL,
	[b_ac_name] [varchar](50) NULL,
	[b_ifsc] [varchar](50) NULL,
	[b_ac_no] [varchar](50) NULL,
	[b_opening_balance] [float] NULL,
	[b_desc] [text] NULL,
 CONSTRAINT [PK_tbl_bank] PRIMARY KEY CLUSTERED 
(
	[b_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_bank_operations]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_bank_operations](
	[bo_id] [int] IDENTITY(1,1) NOT NULL,
	[bo_date] [date] NULL,
	[bo_bank] [varchar](max) NULL,
	[bo_name] [varchar](max) NULL,
	[bo_amount] [float] NULL,
	[bo_category] [varchar](max) NULL,
	[bo_remark] [varchar](max) NULL,
	[bo_file] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_bank_operations] PRIMARY KEY CLUSTERED 
(
	[bo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Calendar]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Calendar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
	[startDate] [datetime] NULL,
	[endDate] [datetime] NULL,
	[color] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[isFullDay] [bit] NULL,
 CONSTRAINT [PK_tbl_Calendar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_challan]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_challan](
	[sl_id] [int] IDENTITY(1,1) NOT NULL,
	[sl_invoice_no] [varchar](50) NULL,
	[sl_date] [date] NULL,
	[sl_customer_name] [varchar](50) NULL,
	[sl_customer_contact] [varchar](50) NULL,
	[sl_customer_address] [varchar](max) NULL,
	[sl_customer_gst_no] [varchar](50) NULL,
	[sl_customer_email] [varchar](max) NULL,
	[sl_designer] [varchar](50) NULL,
	[sl_invoice_date] [date] NULL,
	[sl_due_date] [date] NULL,
	[sl_total_quantity] [decimal](18, 0) NULL,
	[sl_discount] [float] NULL,
	[sl_sub_total] [float] NULL,
	[sl_total_gst] [float] NULL,
	[sl_shipping_charges] [float] NULL,
	[sl_adjustment] [float] NULL,
	[sl_total] [decimal](18, 0) NULL,
	[sl_total_cgst] [float] NULL,
	[sl_total_sgst] [float] NULL,
	[sl_total_igst] [float] NULL,
	[sl_total_taxable] [float] NULL,
	[sl_balance] [decimal](18, 0) NULL,
	[c_id] [int] NULL,
	[sl_design_charges] [float] NULL,
	[sl_fitting_charges] [float] NULL,
	[sl_final_total] [float] NULL,
	[sl_payment_mode] [varchar](50) NULL,
	[sl_framing_charges] [float] NULL,
 CONSTRAINT [PK_tbl_challan_1] PRIMARY KEY CLUSTERED 
(
	[sl_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_challan_invoice]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_challan_invoice](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[s_invoice_no] [varchar](50) NULL,
	[s_date] [date] NULL,
	[s_customer_name] [varchar](50) NULL,
	[s_customer_contact] [varchar](50) NULL,
	[s_customer_address] [varchar](max) NULL,
	[s_customer_gst_no] [varchar](50) NULL,
	[s_customer_email] [varchar](max) NULL,
	[s_designer] [varchar](50) NULL,
	[s_invoice_date] [date] NULL,
	[s_due_date] [date] NULL,
	[s_product_name] [varchar](50) NULL,
	[s_quantity] [decimal](18, 0) NULL,
	[s_total_quantity] [decimal](18, 0) NULL,
	[s_rate] [float] NULL,
	[s_discount] [float] NULL,
	[s_cgstp] [float] NULL,
	[s_cgsta] [float] NULL,
	[s_sgstp] [float] NULL,
	[s_sgsta] [float] NULL,
	[s_igstp] [float] NULL,
	[s_igsta] [float] NULL,
	[s_amount] [float] NULL,
	[s_sub_total] [float] NULL,
	[s_total_gst] [float] NULL,
	[s_shipping_charges] [float] NULL,
	[s_adjustment] [float] NULL,
	[s_total] [decimal](18, 0) NULL,
	[s_stotal] [float] NULL,
	[s_product_hsn] [varchar](50) NULL,
	[s_unit] [varchar](50) NULL,
	[s_desc] [text] NULL,
	[s_height] [float] NULL,
	[s_width] [float] NULL,
	[s_size] [float] NULL,
	[s_samount] [float] NULL,
	[s_status] [varchar](50) NULL,
	[s_total_cgst] [float] NULL,
	[s_total_sgst] [float] NULL,
	[s_total_igst] [float] NULL,
	[s_total_taxable] [float] NULL,
	[s_balance] [decimal](18, 0) NULL,
	[c_id] [int] NULL,
	[s_design_charges] [float] NULL,
	[s_fitting_charges] [float] NULL,
	[s_final_total] [float] NULL,
	[s_payment_mode] [varchar](50) NULL,
	[s_framing_charges] [float] NULL,
 CONSTRAINT [PK_tbl_challan_invoice] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_city]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_city](
	[ct_id] [int] IDENTITY(1,1) NOT NULL,
	[ct_name] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_city] PRIMARY KEY CLUSTERED 
(
	[ct_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_company_details]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_company_details](
	[com_id] [int] IDENTITY(1,1) NOT NULL,
	[com_company_name] [varchar](50) NULL,
	[com_company_name2] [varchar](50) NULL,
	[com_owner_name] [varchar](50) NULL,
	[com_address] [varchar](max) NULL,
	[com_contact] [varchar](50) NULL,
	[com_gst_no] [varchar](50) NULL,
	[com_email] [varchar](50) NULL,
	[com_website] [varchar](50) NULL,
	[com_company_logo] [varchar](max) NULL,
	[com_bank_name] [varchar](50) NULL,
	[com_branch] [varchar](50) NULL,
	[com_acc_no] [varchar](50) NULL,
	[com_ifsc] [varchar](50) NULL,
	[com_company_logo2] [varchar](max) NULL,
	[com_note] [varchar](max) NULL,
	[com_otpno] [varchar](50) NULL,
	[com_created_date] [date] NULL,
	[client_id] [int] NULL,
	[com_upino] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_company_details] PRIMARY KEY CLUSTERED 
(
	[com_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_customer]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_customer](
	[c_id] [int] IDENTITY(1,1) NOT NULL,
	[c_name] [varchar](50) NULL,
	[c_address] [varchar](max) NULL,
	[c_contact] [varchar](50) NULL,
	[c_contact2] [varchar](50) NULL,
	[c_gst_no] [varchar](50) NULL,
	[c_opening_balance] [decimal](18, 0) NULL,
	[c_email] [varchar](50) NULL,
	[c_dob] [date] NULL,
	[c_anidate] [date] NULL,
 CONSTRAINT [PK_tbl_customer] PRIMARY KEY CLUSTERED 
(
	[c_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_customer_payment]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_customer_payment](
	[cp_id] [int] IDENTITY(1,1) NOT NULL,
	[cp_date] [date] NULL,
	[cp_customer_name] [varchar](50) NULL,
	[cp_balance] [decimal](18, 0) NULL,
	[cp_advance] [decimal](18, 0) NULL,
	[cp_mode] [varchar](50) NULL,
	[cp_total_balance] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tbl_customer_payment] PRIMARY KEY CLUSTERED 
(
	[cp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_email_config]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_email_config](
	[ec_id] [int] NOT NULL,
	[ec_email] [varchar](max) NULL,
	[ec_password] [varchar](max) NULL,
	[ec_port] [varchar](50) NULL,
	[ec_subject] [varchar](max) NULL,
	[ec_smtp] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_email_config] PRIMARY KEY CLUSTERED 
(
	[ec_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_estimate]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_estimate](
	[est_id] [int] IDENTITY(1,1) NOT NULL,
	[est_invoice_no] [varchar](50) NULL,
	[est_date] [date] NULL,
	[c_id] [int] NULL,
	[est_order_no] [varchar](50) NULL,
	[est_invoice_date] [date] NULL,
	[est_due_date] [date] NULL,
	[est_total_quantity] [decimal](18, 0) NULL,
	[est_discount] [float] NULL,
	[est_sub_total] [float] NULL,
	[est_shipping_charges] [float] NULL,
	[est_adjustment] [float] NULL,
	[est_total] [decimal](18, 0) NULL,
	[est_balance] [decimal](18, 0) NULL,
	[est_dtp_charges] [float] NULL,
	[est_fitting_charges] [float] NULL,
	[est_payment_method] [varchar](50) NULL,
	[est_order_ref] [varchar](50) NULL,
	[est_pasting_charges] [float] NULL,
	[est_framing_charges] [float] NULL,
	[est_installation_charges] [float] NULL,
 CONSTRAINT [PK_tbl_estimate_1] PRIMARY KEY CLUSTERED 
(
	[est_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_estimate_details]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_estimate_details](
	[es_id] [int] IDENTITY(1,1) NOT NULL,
	[es_invoice_no] [varchar](50) NULL,
	[es_date] [date] NULL,
	[c_id] [int] NULL,
	[es_order_no] [varchar](50) NULL,
	[es_invoice_date] [date] NULL,
	[es_due_date] [date] NULL,
	[es_product_name] [varchar](50) NULL,
	[es_quantity] [decimal](18, 0) NULL,
	[es_total_quantity] [decimal](18, 0) NULL,
	[es_rate] [float] NULL,
	[es_discount] [float] NULL,
	[es_sub_total] [float] NULL,
	[es_shipping_charges] [float] NULL,
	[es_adjustment] [float] NULL,
	[es_total] [decimal](18, 0) NULL,
	[es_hsn] [varchar](50) NULL,
	[es_unit] [varchar](50) NULL,
	[es_stotal] [float] NULL,
	[es_desc] [text] NULL,
	[es_height] [float] NULL,
	[es_width] [float] NULL,
	[es_size] [float] NULL,
	[es_samount] [float] NULL,
	[es_balance] [decimal](18, 0) NULL,
	[es_dtp_charges] [float] NULL,
	[es_fitting_charges] [float] NULL,
	[es_payment_method] [varchar](50) NULL,
	[es_order_ref] [varchar](50) NULL,
	[es_material] [float] NULL,
	[es_pasting_charges] [float] NULL,
	[es_framing_charges] [float] NULL,
	[es_installation_charges] [float] NULL,
 CONSTRAINT [PK_tbl_estimate_details_1] PRIMARY KEY CLUSTERED 
(
	[es_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_expense]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_expense](
	[e_id] [int] IDENTITY(1,1) NOT NULL,
	[e_category_name] [varchar](50) NULL,
	[e_user_name] [varchar](50) NULL,
	[e_amount] [float] NULL,
	[e_count] [decimal](18, 0) NULL,
	[e_date] [date] NULL,
	[e_desc] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_expense] PRIMARY KEY CLUSTERED 
(
	[e_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_expense_category]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_expense_category](
	[cat_id] [int] IDENTITY(1,1) NOT NULL,
	[cat_category_name] [varchar](50) NULL,
	[cat_date] [date] NULL,
 CONSTRAINT [PK_tbl_expense_category] PRIMARY KEY CLUSTERED 
(
	[cat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_expense_user]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_expense_user](
	[u_id] [int] IDENTITY(1,1) NOT NULL,
	[u_user_name] [varchar](50) NULL,
	[u_contact] [varchar](50) NULL,
	[u_desc] [text] NULL,
 CONSTRAINT [PK_tbl_expense_user] PRIMARY KEY CLUSTERED 
(
	[u_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_feature]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_feature](
	[fe_id] [int] NOT NULL,
	[fe_sms] [int] NULL,
	[fe_mail] [int] NULL,
	[fe_del] [int] NULL,
	[fe_otp] [int] NULL,
 CONSTRAINT [PK_tbl_feature] PRIMARY KEY CLUSTERED 
(
	[fe_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_feet]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_feet](
	[f_id] [int] IDENTITY(1,1) NOT NULL,
	[f_feet] [varchar](max) NULL,
	[f_mtr] [float] NULL,
 CONSTRAINT [PK_tbl_feet] PRIMARY KEY CLUSTERED 
(
	[f_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_gallery]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_gallery](
	[gal_id] [int] IDENTITY(1,1) NOT NULL,
	[gal_image] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_gallery] PRIMARY KEY CLUSTERED 
(
	[gal_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_gst_quotation]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_gst_quotation](
	[qu_id] [int] IDENTITY(1,1) NOT NULL,
	[qu_invoice_no] [varchar](50) NULL,
	[qu_date] [date] NULL,
	[c_id] [int] NULL,
	[qu_invoice_date] [date] NULL,
	[qu_due_date] [date] NULL,
	[qu_total_quantity] [decimal](18, 0) NULL,
	[qu_discount] [float] NULL,
	[qu_sub_total] [float] NULL,
	[qu_total_gst] [float] NULL,
	[qu_shipping_charges] [float] NULL,
	[qu_adjustment] [float] NULL,
	[qu_total] [decimal](18, 0) NULL,
	[qu_balance] [float] NULL,
	[qu_dtp_charges] [float] NULL,
	[qu_fitting_charges] [float] NULL,
	[qu_payment_method] [varchar](50) NULL,
	[qu_pasting_charges] [float] NULL,
 CONSTRAINT [PK_tbl_gst_quotation] PRIMARY KEY CLUSTERED 
(
	[qu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_gst_quotation_details]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_gst_quotation_details](
	[q_id] [int] IDENTITY(1,1) NOT NULL,
	[q_quotation_no] [varchar](50) NULL,
	[q_date] [date] NULL,
	[c_id] [int] NULL,
	[q_quotation_date] [date] NULL,
	[q_valid_date] [date] NULL,
	[q_product_name] [varchar](50) NULL,
	[q_quantity] [decimal](18, 0) NULL,
	[q_total_quantity] [decimal](18, 0) NULL,
	[q_rate] [float] NULL,
	[q_discount] [float] NULL,
	[q_cgstp] [float] NULL,
	[q_cgsta] [float] NULL,
	[q_sgstp] [float] NULL,
	[q_sgsta] [float] NULL,
	[q_igstp] [float] NULL,
	[q_igsta] [float] NULL,
	[q_amount] [float] NULL,
	[q_sub_total] [float] NULL,
	[q_total_gst] [float] NULL,
	[q_shipping_charges] [float] NULL,
	[q_adjustment] [float] NULL,
	[q_total] [decimal](18, 0) NULL,
	[q_stotal] [float] NULL,
	[q_hsn] [varchar](50) NULL,
	[q_unit] [varchar](50) NULL,
	[q_desc] [text] NULL,
	[q_height] [float] NULL,
	[q_width] [float] NULL,
	[q_size] [float] NULL,
	[q_samount] [float] NULL,
	[q_balance] [float] NULL,
	[q_dtp_charges] [float] NULL,
	[q_fitting_charges] [float] NULL,
	[q_payment_method] [varchar](50) NULL,
	[q_pasting_charges] [float] NULL,
 CONSTRAINT [PK_tbl_gst_quotation_details] PRIMARY KEY CLUSTERED 
(
	[q_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_invoice_image]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_invoice_image](
	[im_id] [int] IDENTITY(1,1) NOT NULL,
	[im_invoice_no] [varchar](50) NULL,
	[im_desc] [text] NULL,
	[im_image] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_invoice_image] PRIMARY KEY CLUSTERED 
(
	[im_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_job_sheet]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_job_sheet](
	[js_id] [int] IDENTITY(1,1) NOT NULL,
	[s_invoice_no] [varchar](50) NULL,
	[js_expense] [text] NULL,
	[js_amount] [float] NULL,
 CONSTRAINT [PK_tbl_job_sheet] PRIMARY KEY CLUSTERED 
(
	[js_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_order]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_order](
	[quw_id] [int] IDENTITY(1,1) NOT NULL,
	[quw_no] [varchar](50) NULL,
	[quw_date] [date] NULL,
	[quw_total_quantity] [decimal](18, 0) NULL,
	[quw_discount] [float] NULL,
	[quw_sub_total] [float] NULL,
	[quw_shipping_charges] [float] NULL,
	[quw_adjustment] [float] NULL,
	[quw_total] [decimal](18, 0) NULL,
	[quw_name] [varchar](50) NULL,
	[quw_phone] [varchar](50) NULL,
	[quw_balance] [float] NULL,
	[quw_dtp_charges] [float] NULL,
	[quw_fitting_charges] [float] NULL,
	[quw_payment_method] [varchar](50) NULL,
	[quw_pasting_charges] [float] NULL,
 CONSTRAINT [PK_tbl_order] PRIMARY KEY CLUSTERED 
(
	[quw_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_order_details]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_order_details](
	[qw_id] [int] IDENTITY(1,1) NOT NULL,
	[quw_no] [varchar](50) NULL,
	[qw_date] [date] NULL,
	[qw_product_name] [varchar](50) NULL,
	[qw_quantity] [decimal](18, 0) NULL,
	[qw_total_quantity] [decimal](18, 0) NULL,
	[qw_rate] [float] NULL,
	[qw_discount] [float] NULL,
	[qw_sub_total] [float] NULL,
	[qw_shipping_charges] [float] NULL,
	[qw_adjustment] [float] NULL,
	[qw_total] [decimal](18, 0) NULL,
	[qw_hsn] [varchar](50) NULL,
	[qw_unit] [varchar](50) NULL,
	[qw_stotal] [float] NULL,
	[qw_desc] [text] NULL,
	[qw_height] [float] NULL,
	[qw_width] [float] NULL,
	[qw_size] [float] NULL,
	[qw_samount] [float] NULL,
	[qw_name] [varchar](50) NULL,
	[qw_phone] [varchar](50) NULL,
	[qw_balance] [float] NULL,
	[qw_dtp_charges] [float] NULL,
	[qw_fitting_charges] [float] NULL,
	[qw_payment_method] [varchar](50) NULL,
	[qw_pasting_charges] [float] NULL,
 CONSTRAINT [PK_tbl_order_details] PRIMARY KEY CLUSTERED 
(
	[qw_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_order_invoice]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_order_invoice](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[s_invoice_no] [varchar](50) NULL,
	[s_date] [date] NULL,
	[s_customer_name] [varchar](50) NULL,
	[s_customer_contact] [varchar](50) NULL,
	[s_customer_address] [varchar](max) NULL,
	[s_customer_gst_no] [varchar](50) NULL,
	[s_customer_email] [varchar](max) NULL,
	[s_designer] [varchar](50) NULL,
	[s_invoice_date] [date] NULL,
	[s_due_date] [date] NULL,
	[s_product_name] [varchar](50) NULL,
	[s_quantity] [decimal](18, 0) NULL,
	[s_total_quantity] [decimal](18, 0) NULL,
	[s_rate] [float] NULL,
	[s_discount] [float] NULL,
	[s_cgstp] [float] NULL,
	[s_cgsta] [float] NULL,
	[s_sgstp] [float] NULL,
	[s_sgsta] [float] NULL,
	[s_igstp] [float] NULL,
	[s_igsta] [float] NULL,
	[s_amount] [float] NULL,
	[s_sub_total] [float] NULL,
	[s_total_gst] [float] NULL,
	[s_shipping_charges] [float] NULL,
	[s_adjustment] [float] NULL,
	[s_total] [decimal](18, 0) NULL,
	[s_stotal] [float] NULL,
	[s_product_hsn] [varchar](50) NULL,
	[s_unit] [varchar](50) NULL,
	[s_desc] [text] NULL,
	[s_height] [float] NULL,
	[s_width] [float] NULL,
	[s_size] [float] NULL,
	[s_samount] [float] NULL,
	[s_status] [varchar](50) NULL,
	[s_total_cgst] [float] NULL,
	[s_total_sgst] [float] NULL,
	[s_total_igst] [float] NULL,
	[s_total_taxable] [float] NULL,
	[s_balance] [decimal](18, 0) NULL,
	[est_dtp_charges] [float] NULL,
	[est_fitting_framing] [float] NULL,
	[est_payment_method] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_order_invoice] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_order_invoice_payment]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_order_invoice_payment](
	[si_id] [int] IDENTITY(1,1) NOT NULL,
	[si_invoice] [varchar](50) NULL,
	[o_id] [int] NULL,
	[si_due] [decimal](18, 0) NULL,
	[si_discount] [decimal](18, 0) NULL,
	[si_pay] [decimal](18, 0) NULL,
	[si_mode] [varchar](50) NULL,
	[si_chno] [varchar](50) NULL,
	[si_balance] [decimal](18, 0) NULL,
	[si_date] [date] NULL,
 CONSTRAINT [PK_tbl_order_invoice_payment] PRIMARY KEY CLUSTERED 
(
	[si_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_product]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_product](
	[p_id] [int] IDENTITY(1,1) NOT NULL,
	[p_name] [varchar](50) NULL,
	[p_unit] [varchar](50) NULL,
	[p_cgst] [varchar](50) NULL,
	[p_sgst] [varchar](50) NULL,
	[p_igst] [varchar](50) NULL,
	[p_hsn_code] [varchar](50) NULL,
	[p_rate] [float] NULL,
	[p_desc] [text] NULL,
 CONSTRAINT [PK_tbl_product] PRIMARY KEY CLUSTERED 
(
	[p_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_purchase]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_purchase](
	[pu_id] [int] IDENTITY(1,1) NOT NULL,
	[pu_invoice_no] [varchar](50) NULL,
	[pu_date] [date] NULL,
	[v_id] [int] NULL,
	[pu_order_no] [varchar](50) NULL,
	[pu_invoice_date] [date] NULL,
	[pu_due_date] [date] NULL,
	[pu_total_quantity] [decimal](18, 0) NULL,
	[pu_discount] [float] NULL,
	[pu_sub_total] [float] NULL,
	[pu_total_gst] [float] NULL,
	[pu_shipping_charges] [float] NULL,
	[pu_adjustment] [float] NULL,
	[pu_total] [decimal](18, 0) NULL,
	[pu_total_cgst] [float] NULL,
	[pu_total_sgst] [float] NULL,
	[pu_total_igst] [float] NULL,
	[pu_total_taxable] [float] NULL,
	[pu_balance] [decimal](18, 0) NULL,
	[pu_product_name] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_purchase] PRIMARY KEY CLUSTERED 
(
	[pu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_purchase_invoice]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_purchase_invoice](
	[pc_id] [int] IDENTITY(1,1) NOT NULL,
	[pc_invoice_no] [varchar](50) NULL,
	[pc_date] [date] NULL,
	[v_id] [int] NULL,
	[pc_order_no] [varchar](50) NULL,
	[pc_invoice_date] [date] NULL,
	[pc_due_date] [date] NULL,
	[pc_product_name] [varchar](50) NULL,
	[pc_quantity] [decimal](18, 0) NULL,
	[pc_total_quantity] [decimal](18, 0) NULL,
	[pc_rate] [float] NULL,
	[pc_discount] [float] NULL,
	[pc_cgstp] [float] NULL,
	[pc_cgsta] [float] NULL,
	[pc_sgstp] [float] NULL,
	[pc_sgsta] [float] NULL,
	[pc_igstp] [float] NULL,
	[pc_igsta] [float] NULL,
	[pc_amount] [float] NULL,
	[pc_sub_total] [float] NULL,
	[pc_total_gst] [float] NULL,
	[pc_shipping_charges] [float] NULL,
	[pc_adjustable] [float] NULL,
	[pc_total] [decimal](18, 0) NULL,
	[pc_stotal] [float] NULL,
	[pc_product_hsn] [varchar](50) NULL,
	[pc_unit] [varchar](50) NULL,
	[pc_desc] [text] NULL,
	[pc_height] [float] NULL,
	[pc_width] [float] NULL,
	[pc_size] [float] NULL,
	[pc_samount] [float] NULL,
	[pc_total_cgst] [float] NULL,
	[pc_total_sgst] [float] NULL,
	[pc_total_igst] [float] NULL,
	[pc_total_taxable] [float] NULL,
	[pc_balance] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tbl_purchase_invoice] PRIMARY KEY CLUSTERED 
(
	[pc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_purchase_invoice_payment]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_purchase_invoice_payment](
	[pi_id] [int] IDENTITY(1,1) NOT NULL,
	[pi_invoice] [varchar](50) NULL,
	[v_id] [int] NULL,
	[pi_due] [decimal](18, 0) NULL,
	[pi_pay] [decimal](18, 0) NULL,
	[pi_mode] [varchar](50) NULL,
	[pi_balance] [decimal](18, 0) NULL,
	[pi_date] [date] NULL,
 CONSTRAINT [PK_tbl_purchase_invoice_payment] PRIMARY KEY CLUSTERED 
(
	[pi_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_purchase_product]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_purchase_product](
	[p_id] [int] IDENTITY(1,1) NOT NULL,
	[p_name] [varchar](50) NULL,
	[p_unit] [varchar](50) NULL,
	[p_cgst] [varchar](50) NULL,
	[p_sgst] [varchar](50) NULL,
	[p_igst] [varchar](50) NULL,
	[p_hsn_code] [varchar](50) NULL,
	[p_rate] [float] NULL,
	[p_desc] [text] NULL,
	[p_stock] [float] NULL,
	[p_value] [float] NULL,
 CONSTRAINT [PK_tbl_purchase_product] PRIMARY KEY CLUSTERED 
(
	[p_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_rate]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_rate](
	[r_id] [int] IDENTITY(1,1) NOT NULL,
	[cust_name] [varchar](max) NULL,
	[p_name] [varchar](max) NULL,
	[r_rate] [float] NULL,
	[c_id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_roll_purchase]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_roll_purchase](
	[rpu_id] [int] IDENTITY(1,1) NOT NULL,
	[rpu_invoice_no] [varchar](50) NULL,
	[rpu_date] [date] NULL,
	[v_id] [int] NULL,
	[rpu_order_no] [varchar](50) NULL,
	[rpu_invoice_date] [date] NULL,
	[rpu_due_date] [date] NULL,
	[rpu_total_quantity] [decimal](18, 0) NULL,
	[rpu_discount] [float] NULL,
	[rpu_sub_total] [float] NULL,
	[rpu_total_gst] [float] NULL,
	[rpu_shipping_charges] [float] NULL,
	[rpu_adjustment] [float] NULL,
	[rpu_total] [decimal](18, 0) NULL,
	[rpu_total_cgst] [float] NULL,
	[rpu_total_sgst] [float] NULL,
	[rpu_total_igst] [float] NULL,
	[rpu_total_taxable] [float] NULL,
	[rpu_balance] [decimal](18, 0) NULL,
	[rpu_product_name] [varchar](50) NULL,
	[rpu_size] [float] NULL,
 CONSTRAINT [PK_tbl_roll_purchase] PRIMARY KEY CLUSTERED 
(
	[rpu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_roll_purchase_invoice]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_roll_purchase_invoice](
	[rpc_id] [int] IDENTITY(1,1) NOT NULL,
	[rpc_invoice_no] [varchar](50) NULL,
	[rpc_date] [date] NULL,
	[v_id] [int] NULL,
	[rpc_order_no] [varchar](50) NULL,
	[rpc_invoice_date] [date] NULL,
	[rpc_due_date] [date] NULL,
	[rpc_product_name] [varchar](50) NULL,
	[rpc_quantity] [decimal](18, 0) NULL,
	[rpc_total_quantity] [decimal](18, 0) NULL,
	[rpc_rate] [float] NULL,
	[rpc_discount] [float] NULL,
	[rpc_cgstp] [float] NULL,
	[rpc_cgsta] [float] NULL,
	[rpc_sgstp] [float] NULL,
	[rpc_sgsta] [float] NULL,
	[rpc_igstp] [float] NULL,
	[rpc_igsta] [float] NULL,
	[rpc_amount] [float] NULL,
	[rpc_sub_total] [float] NULL,
	[rpc_total_gst] [float] NULL,
	[rpc_shipping_charges] [float] NULL,
	[rpc_adjustable] [float] NULL,
	[rpc_total] [decimal](18, 0) NULL,
	[rpc_stotal] [float] NULL,
	[rpc_product_hsn] [varchar](50) NULL,
	[rpc_unit] [varchar](50) NULL,
	[rpc_desc] [text] NULL,
	[rpc_heightft] [varchar](255) NULL,
	[rpc_heightmtr] [float] NULL,
	[rpc_roll_size] [float] NULL,
	[rpc_total_size] [float] NULL,
	[rpc_size] [float] NULL,
	[rpc_samount] [float] NULL,
	[rpc_total_cgst] [float] NULL,
	[rpc_total_sgst] [float] NULL,
	[rpc_total_igst] [float] NULL,
	[rpc_total_taxable] [float] NULL,
	[rpc_balance] [decimal](18, 0) NULL,
	[rpc_mode] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_roll_purchase_invoice] PRIMARY KEY CLUSTERED 
(
	[rpc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_roll_purchase_invoice_payment]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_roll_purchase_invoice_payment](
	[rpi_id] [int] IDENTITY(1,1) NOT NULL,
	[rpi_invoice] [varchar](50) NULL,
	[v_id] [varchar](50) NULL,
	[rpi_due] [decimal](18, 0) NULL,
	[rpi_pay] [decimal](18, 0) NULL,
	[rpi_mode] [varchar](50) NULL,
	[rpi_balance] [decimal](18, 0) NULL,
	[rpi_date] [date] NULL,
 CONSTRAINT [PK_tbl_roll_purchase_invoice_payment] PRIMARY KEY CLUSTERED 
(
	[rpi_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_salary]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_salary](
	[sal_id] [int] IDENTITY(1,1) NOT NULL,
	[st_id] [int] NULL,
	[sal_salary] [decimal](18, 0) NULL,
	[sal_pay] [decimal](18, 0) NULL,
	[sal_deduction] [decimal](18, 0) NULL,
	[sal_balance] [decimal](18, 0) NULL,
	[sal_month] [varchar](50) NULL,
	[sal_date] [date] NULL,
	[sal_remark] [text] NULL,
 CONSTRAINT [PK_tbl_salary] PRIMARY KEY CLUSTERED 
(
	[sal_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_sale]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_sale](
	[sl_id] [int] IDENTITY(1,1) NOT NULL,
	[sl_invoice_no] [varchar](50) NULL,
	[sl_date] [date] NULL,
	[c_id] [int] NULL,
	[sl_order_no] [varchar](50) NULL,
	[sl_invoice_date] [date] NULL,
	[sl_due_date] [date] NULL,
	[sl_total_quantity] [decimal](18, 0) NULL,
	[sl_discount] [float] NULL,
	[sl_sub_total] [float] NULL,
	[sl_total_gst] [float] NULL,
	[sl_shipping_charges] [float] NULL,
	[sl_adjustment] [float] NULL,
	[sl_total] [decimal](18, 0) NULL,
	[sl_total_cgst] [float] NULL,
	[sl_total_sgst] [float] NULL,
	[sl_total_igst] [float] NULL,
	[sl_total_taxable] [float] NULL,
	[sl_balance] [decimal](18, 0) NULL,
	[sl_dtp_charges] [float] NULL,
	[sl_fitting_charges] [float] NULL,
	[sl_payment_method] [varchar](50) NULL,
	[sl_order_ref] [varchar](50) NULL,
	[sl_transaction_type] [varchar](50) NULL,
	[sl_cess] [float] NULL,
	[sl_pasting_charges] [float] NULL,
	[sl_framing_charges] [float] NULL,
	[sl_installation_charges] [float] NULL,
	[sl_upichqno] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_sale] PRIMARY KEY CLUSTERED 
(
	[sl_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_sale_invoice]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_sale_invoice](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[s_invoice_no] [varchar](50) NULL,
	[s_date] [date] NULL,
	[c_id] [int] NULL,
	[s_order_no] [varchar](50) NULL,
	[s_invoice_date] [date] NULL,
	[s_due_date] [date] NULL,
	[s_product_name] [varchar](50) NULL,
	[s_quantity] [decimal](18, 0) NULL,
	[s_total_quantity] [decimal](18, 0) NULL,
	[s_rate] [float] NULL,
	[s_discount] [float] NULL,
	[s_cgstp] [float] NULL,
	[s_cgsta] [float] NULL,
	[s_sgstp] [float] NULL,
	[s_sgsta] [float] NULL,
	[s_igstp] [float] NULL,
	[s_igsta] [float] NULL,
	[s_amount] [float] NULL,
	[s_sub_total] [float] NULL,
	[s_total_gst] [float] NULL,
	[s_shipping_charges] [float] NULL,
	[s_adjustment] [float] NULL,
	[s_total] [decimal](18, 0) NULL,
	[s_stotal] [float] NULL,
	[s_product_hsn] [varchar](50) NULL,
	[s_unit] [varchar](50) NULL,
	[s_desc] [text] NULL,
	[s_height] [float] NULL,
	[s_width] [float] NULL,
	[s_size] [float] NULL,
	[s_samount] [float] NULL,
	[s_total_cgst] [float] NULL,
	[s_total_sgst] [float] NULL,
	[s_total_igst] [float] NULL,
	[s_total_taxable] [float] NULL,
	[s_balance] [decimal](18, 0) NULL,
	[s_dtp_charges] [float] NULL,
	[s_fitting_charges] [float] NULL,
	[s_payment_method] [varchar](50) NULL,
	[s_order_ref] [varchar](50) NULL,
	[s_transaction_type] [varchar](50) NULL,
	[s_cess] [float] NULL,
	[s_material] [float] NULL,
	[s_pasting_charges] [float] NULL,
	[s_framing_charges] [float] NULL,
	[s_installation_charges] [float] NULL,
	[s_upichqno] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_sale_invoice] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_sale_invoice_payment]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_sale_invoice_payment](
	[si_id] [int] IDENTITY(1,1) NOT NULL,
	[si_invoice] [varchar](50) NULL,
	[c_id] [int] NULL,
	[si_due] [decimal](18, 0) NULL,
	[si_discount] [decimal](18, 0) NULL,
	[si_pay] [decimal](18, 0) NULL,
	[si_mode] [varchar](50) NULL,
	[si_chno] [varchar](50) NULL,
	[si_balance] [decimal](18, 0) NULL,
	[si_date] [date] NULL,
	[si_upichqno] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_sale_invoice_payment] PRIMARY KEY CLUSTERED 
(
	[si_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_sms_config]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_sms_config](
	[sc_id] [int] NOT NULL,
	[sc_key] [varchar](50) NULL,
	[sc_country] [int] NULL,
	[sc_sender] [varchar](50) NULL,
	[sc_route] [text] NULL,
 CONSTRAINT [PK_tbl_sms_config] PRIMARY KEY CLUSTERED 
(
	[sc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_staff]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_staff](
	[st_id] [int] IDENTITY(1,1) NOT NULL,
	[st_staff_name] [varchar](50) NULL,
	[st_address] [varchar](max) NULL,
	[st_contact] [varchar](50) NULL,
	[st_dob] [date] NULL,
	[st_gender] [varchar](50) NULL,
	[st_designation] [varchar](50) NULL,
	[st_salary] [decimal](18, 0) NULL,
	[st_balance] [decimal](18, 0) NULL,
	[st_joining_date] [date] NULL,
	[st_left_date] [date] NULL,
 CONSTRAINT [PK_tbl_staff] PRIMARY KEY CLUSTERED 
(
	[st_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_temp_challan_invoice]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_temp_challan_invoice](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[s_invoice_no] [varchar](50) NULL,
	[s_date] [date] NULL,
	[s_customer_name] [varchar](50) NULL,
	[s_customer_contact] [varchar](50) NULL,
	[s_customer_address] [varchar](max) NULL,
	[s_customer_gst_no] [varchar](50) NULL,
	[s_customer_email] [varchar](max) NULL,
	[s_designer] [varchar](50) NULL,
	[s_invoice_date] [date] NULL,
	[s_due_date] [date] NULL,
	[s_product_name] [varchar](50) NULL,
	[s_quantity] [decimal](18, 0) NULL,
	[s_total_quantity] [decimal](18, 0) NULL,
	[s_rate] [float] NULL,
	[s_discount] [float] NULL,
	[s_cgstp] [float] NULL,
	[s_cgsta] [float] NULL,
	[s_sgstp] [float] NULL,
	[s_sgsta] [float] NULL,
	[s_igstp] [float] NULL,
	[s_igsta] [float] NULL,
	[s_amount] [float] NULL,
	[s_sub_total] [float] NULL,
	[s_total_gst] [float] NULL,
	[s_shipping_charges] [float] NULL,
	[s_adjustment] [float] NULL,
	[s_total] [decimal](18, 0) NULL,
	[s_stotal] [float] NULL,
	[s_product_hsn] [varchar](50) NULL,
	[s_unit] [varchar](50) NULL,
	[s_desc] [text] NULL,
	[s_height] [float] NULL,
	[s_width] [float] NULL,
	[s_size] [float] NULL,
	[s_samount] [float] NULL,
	[s_status] [varchar](50) NULL,
	[s_total_cgst] [float] NULL,
	[s_total_sgst] [float] NULL,
	[s_total_igst] [float] NULL,
	[s_total_taxable] [float] NULL,
	[s_balance] [decimal](18, 0) NULL,
	[c_id] [int] NULL,
	[s_design_charges] [float] NULL,
	[s_fitting_charges] [float] NULL,
	[s_final_total] [float] NULL,
	[s_payment_mode] [varchar](50) NULL,
	[s_framing_charges] [float] NULL,
 CONSTRAINT [PK_tbl_temp_challan_invoice] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_temp_estimate_details]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_temp_estimate_details](
	[es_id] [int] IDENTITY(1,1) NOT NULL,
	[es_invoice_no] [varchar](50) NULL,
	[es_date] [date] NULL,
	[c_id] [int] NULL,
	[es_order_no] [varchar](50) NULL,
	[es_invoice_date] [date] NULL,
	[es_due_date] [date] NULL,
	[es_product_name] [varchar](50) NULL,
	[es_quantity] [decimal](18, 0) NULL,
	[es_total_quantity] [decimal](18, 0) NULL,
	[es_rate] [float] NULL,
	[es_discount] [float] NULL,
	[es_sub_total] [float] NULL,
	[es_shipping_charges] [float] NULL,
	[es_adjustment] [float] NULL,
	[es_total] [decimal](18, 0) NULL,
	[es_hsn] [varchar](50) NULL,
	[es_unit] [varchar](50) NULL,
	[es_stotal] [float] NULL,
	[es_desc] [text] NULL,
	[es_height] [float] NULL,
	[es_width] [float] NULL,
	[es_size] [float] NULL,
	[es_samount] [float] NULL,
	[es_balance] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tbl_temp_estimate_details] PRIMARY KEY CLUSTERED 
(
	[es_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_temp_gst_quotation_details]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_temp_gst_quotation_details](
	[q_id] [int] IDENTITY(1,1) NOT NULL,
	[q_quotation_no] [varchar](50) NULL,
	[q_date] [date] NULL,
	[c_id] [int] NULL,
	[q_quotation_date] [date] NULL,
	[q_valid_date] [date] NULL,
	[q_product_name] [varchar](50) NULL,
	[q_quantity] [decimal](18, 0) NULL,
	[q_total_quantity] [decimal](18, 0) NULL,
	[q_rate] [float] NULL,
	[q_discount] [float] NULL,
	[q_cgstp] [float] NULL,
	[q_cgsta] [float] NULL,
	[q_sgstp] [float] NULL,
	[q_sgsta] [float] NULL,
	[q_igstp] [float] NULL,
	[q_igsta] [float] NULL,
	[q_amount] [float] NULL,
	[q_sub_total] [float] NULL,
	[q_total_gst] [float] NULL,
	[q_shipping_charges] [float] NULL,
	[q_adjustment] [float] NULL,
	[q_total] [decimal](18, 0) NULL,
	[q_stotal] [float] NULL,
	[q_hsn] [varchar](50) NULL,
	[q_unit] [varchar](50) NULL,
	[q_desc] [text] NULL,
	[q_height] [float] NULL,
	[q_width] [float] NULL,
	[q_size] [float] NULL,
	[q_samount] [float] NULL,
 CONSTRAINT [PK_tbl_temp_gst_quotation_details] PRIMARY KEY CLUSTERED 
(
	[q_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_temp_purchase_invoice]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_temp_purchase_invoice](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[s_invoice_no] [varchar](50) NULL,
	[s_date] [date] NULL,
	[v_id] [int] NULL,
	[s_order_no] [varchar](50) NULL,
	[s_invoice_date] [date] NULL,
	[s_due_date] [date] NULL,
	[s_product_name] [varchar](50) NULL,
	[s_quantity] [decimal](18, 0) NULL,
	[s_total_quantity] [decimal](18, 0) NULL,
	[s_rate] [float] NULL,
	[s_discount] [float] NULL,
	[s_cgstp] [float] NULL,
	[s_cgsta] [float] NULL,
	[s_sgstp] [float] NULL,
	[s_sgsta] [float] NULL,
	[s_igstp] [float] NULL,
	[s_igsta] [float] NULL,
	[s_amount] [float] NULL,
	[s_sub_total] [float] NULL,
	[s_total_gst] [float] NULL,
	[s_shipping_charges] [float] NULL,
	[s_adjustment] [float] NULL,
	[s_total] [decimal](18, 0) NULL,
	[s_stotal] [float] NULL,
	[s_product_hsn] [varchar](50) NULL,
	[s_unit] [varchar](50) NULL,
	[s_desc] [text] NULL,
	[s_height] [float] NULL,
	[s_width] [float] NULL,
	[s_size] [float] NULL,
	[s_samount] [float] NULL,
	[s_total_cgst] [float] NULL,
	[s_total_sgst] [float] NULL,
	[s_total_igst] [float] NULL,
	[s_total_taxable] [float] NULL,
	[s_balance] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tbl_temp_purchase_invoice] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_temp_roll_purchase_invoice]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_temp_roll_purchase_invoice](
	[rpc_id] [int] IDENTITY(1,1) NOT NULL,
	[rpc_invoice_no] [varchar](50) NULL,
	[rpc_date] [date] NULL,
	[v_id] [int] NULL,
	[rpc_order_no] [varchar](50) NULL,
	[rpc_invoice_date] [date] NULL,
	[rpc_due_date] [date] NULL,
	[rpc_product_name] [varchar](50) NULL,
	[rpc_quantity] [decimal](18, 0) NULL,
	[rpc_total_quantity] [decimal](18, 0) NULL,
	[rpc_rate] [float] NULL,
	[rpc_discount] [float] NULL,
	[rpc_cgstp] [float] NULL,
	[rpc_cgsta] [float] NULL,
	[rpc_sgstp] [float] NULL,
	[rpc_sgsta] [float] NULL,
	[rpc_igstp] [float] NULL,
	[rpc_igsta] [float] NULL,
	[rpc_amount] [float] NULL,
	[rpc_sub_total] [float] NULL,
	[rpc_total_gst] [float] NULL,
	[rpc_shipping_charges] [float] NULL,
	[rpc_adjustable] [float] NULL,
	[rpc_total] [decimal](18, 0) NULL,
	[rpc_stotal] [float] NULL,
	[rpc_product_hsn] [varchar](50) NULL,
	[rpc_unit] [varchar](50) NULL,
	[rpc_desc] [text] NULL,
	[rpc_heightft] [float] NULL,
	[rpc_heightmtr] [float] NULL,
	[rpc_roll_size] [float] NULL,
	[rpc_total_size] [float] NULL,
	[rpc_size] [float] NULL,
	[rpc_samount] [float] NULL,
	[rpc_total_cgst] [float] NULL,
	[rpc_total_sgst] [float] NULL,
	[rpc_total_igst] [float] NULL,
	[rpc_total_taxable] [float] NULL,
	[rpc_balance] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tbl_temp_roll_purchase_invoice_1] PRIMARY KEY CLUSTERED 
(
	[rpc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_temp_sale_invoice]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_temp_sale_invoice](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[s_invoice_no] [varchar](50) NULL,
	[s_date] [date] NULL,
	[c_id] [int] NULL,
	[s_order_no] [varchar](50) NULL,
	[s_invoice_date] [date] NULL,
	[s_due_date] [date] NULL,
	[s_product_name] [varchar](50) NULL,
	[s_quantity] [decimal](18, 0) NULL,
	[s_total_quantity] [decimal](18, 0) NULL,
	[s_rate] [float] NULL,
	[s_discount] [float] NULL,
	[s_cgstp] [float] NULL,
	[s_cgsta] [float] NULL,
	[s_sgstp] [float] NULL,
	[s_sgsta] [float] NULL,
	[s_igstp] [float] NULL,
	[s_igsta] [float] NULL,
	[s_amount] [float] NULL,
	[s_sub_total] [float] NULL,
	[s_total_gst] [float] NULL,
	[s_shipping_charges] [float] NULL,
	[s_adjustment] [float] NULL,
	[s_total] [decimal](18, 0) NULL,
	[s_stotal] [float] NULL,
	[s_product_hsn] [varchar](50) NULL,
	[s_unit] [varchar](50) NULL,
	[s_desc] [text] NULL,
	[s_height] [float] NULL,
	[s_width] [float] NULL,
	[s_size] [float] NULL,
	[s_samount] [float] NULL,
	[s_total_cgst] [float] NULL,
	[s_total_sgst] [float] NULL,
	[s_total_igst] [float] NULL,
	[s_total_taxable] [float] NULL,
	[s_balance] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tbl_temp_sale_invoice_1] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_temp_without_gst_quotation_details]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_temp_without_gst_quotation_details](
	[qw_id] [int] IDENTITY(1,1) NOT NULL,
	[qw_quotation_no] [varchar](50) NULL,
	[qw_date] [date] NULL,
	[c_id] [int] NULL,
	[qw_quotation_date] [date] NULL,
	[qw_valid_date] [date] NULL,
	[qw_product_name] [varchar](50) NULL,
	[qw_quantity] [decimal](18, 0) NULL,
	[qw_total_quantity] [decimal](18, 0) NULL,
	[qw_rate] [float] NULL,
	[qw_discount] [float] NULL,
	[qw_sub_total] [float] NULL,
	[qw_shipping_charges] [float] NULL,
	[qw_adjustment] [float] NULL,
	[qw_total] [decimal](18, 0) NULL,
	[qw_hsn] [varchar](50) NULL,
	[qw_unit] [varchar](50) NULL,
	[qw_stotal] [float] NULL,
	[qw_desc] [text] NULL,
	[qw_height] [float] NULL,
	[qw_width] [float] NULL,
	[qw_size] [float] NULL,
	[qw_samount] [float] NULL,
 CONSTRAINT [PK_tbl_temp_without_gst_quotation_details] PRIMARY KEY CLUSTERED 
(
	[qw_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_used_stock]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_used_stock](
	[u_id] [int] IDENTITY(1,1) NOT NULL,
	[p_name] [varchar](max) NULL,
	[date] [date] NULL,
	[sqrft] [float] NULL,
	[quanity] [float] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_vendor]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_vendor](
	[v_id] [int] IDENTITY(1,1) NOT NULL,
	[v_name] [varchar](50) NULL,
	[v_address] [varchar](max) NULL,
	[v_contact] [varchar](50) NULL,
	[v_gst_no] [varchar](50) NULL,
	[v_opening_balance] [decimal](18, 0) NULL,
	[v_email] [varchar](max) NULL,
	[v_contact2] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_vendor] PRIMARY KEY CLUSTERED 
(
	[v_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_vendor_payment]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_vendor_payment](
	[vp_id] [int] IDENTITY(1,1) NOT NULL,
	[vp_date] [date] NULL,
	[vp_vendor_name] [varchar](50) NULL,
	[vp_balance] [decimal](18, 0) NULL,
	[vp_advance] [decimal](18, 0) NULL,
	[vp_mode] [varchar](50) NULL,
	[vp_total_balance] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tbl_vendor_payment] PRIMARY KEY CLUSTERED 
(
	[vp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_without_gst_quotation]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_without_gst_quotation](
	[quw_id] [int] IDENTITY(1,1) NOT NULL,
	[quw_invoice_no] [varchar](50) NULL,
	[quw_date] [date] NULL,
	[c_id] [int] NULL,
	[quw_invoice_date] [date] NULL,
	[quw_due_date] [date] NULL,
	[quw_total_quantity] [decimal](18, 0) NULL,
	[quw_discount] [float] NULL,
	[quw_sub_total] [float] NULL,
	[quw_shipping_charges] [float] NULL,
	[quw_adjustment] [float] NULL,
	[quw_total] [decimal](18, 0) NULL,
	[quw_balance] [varchar](50) NULL,
	[quw_dtp_charges] [float] NULL,
	[quw_fitting_charges] [float] NULL,
	[quw_payment_method] [varchar](50) NULL,
	[quw_pasting_charges] [float] NULL,
 CONSTRAINT [PK_tbl_without_gst_quotation] PRIMARY KEY CLUSTERED 
(
	[quw_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_without_gst_quotation_details]    Script Date: 2022-07-21 17:26:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_without_gst_quotation_details](
	[qw_id] [int] IDENTITY(1,1) NOT NULL,
	[qw_quotation_no] [varchar](50) NULL,
	[qw_date] [date] NULL,
	[c_id] [int] NULL,
	[qw_quotation_date] [date] NULL,
	[qw_valid_date] [date] NULL,
	[qw_product_name] [varchar](50) NULL,
	[qw_quantity] [decimal](18, 0) NULL,
	[qw_total_quantity] [decimal](18, 0) NULL,
	[qw_rate] [float] NULL,
	[qw_discount] [float] NULL,
	[qw_sub_total] [float] NULL,
	[qw_shipping_charges] [float] NULL,
	[qw_adjustment] [float] NULL,
	[qw_total] [decimal](18, 0) NULL,
	[qw_hsn] [varchar](50) NULL,
	[qw_unit] [varchar](50) NULL,
	[qw_stotal] [float] NULL,
	[qw_desc] [text] NULL,
	[qw_height] [float] NULL,
	[qw_width] [float] NULL,
	[qw_size] [float] NULL,
	[qw_samount] [float] NULL,
	[qw_balance] [varchar](50) NULL,
	[qw_dtp_charges] [float] NULL,
	[qw_fitting_charges] [float] NULL,
	[qw_payment_method] [varchar](50) NULL,
	[qw_pasting_charges] [float] NULL,
 CONSTRAINT [PK_tbl_without_gst_quotation_details] PRIMARY KEY CLUSTERED 
(
	[qw_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_admin_login] ON 

INSERT [dbo].[tbl_admin_login] ([a_id], [a_email], [a_password]) VALUES (1, N'Shagun', N'12345')
SET IDENTITY_INSERT [dbo].[tbl_admin_login] OFF
SET IDENTITY_INSERT [dbo].[tbl_admin_role] ON 

INSERT [dbo].[tbl_admin_role] ([ar_id], [ar_name], [ar_date]) VALUES (1, N'Designer', CAST(0x07440B00 AS Date))
SET IDENTITY_INSERT [dbo].[tbl_admin_role] OFF
SET IDENTITY_INSERT [dbo].[tbl_admin_user] ON 

INSERT [dbo].[tbl_admin_user] ([au_id], [au_role], [au_name], [au_email], [au_password]) VALUES (1, N'Designer', N'Vikram', N'vikram@shagun.com', N'12345')
SET IDENTITY_INSERT [dbo].[tbl_admin_user] OFF
SET IDENTITY_INSERT [dbo].[tbl_Calendar] ON 

INSERT [dbo].[tbl_Calendar] ([Id], [title], [startDate], [endDate], [color], [Description], [isFullDay]) VALUES (1, N'Chan', CAST(0x0000AEC100000000 AS DateTime), CAST(0x0000AEC200000000 AS DateTime), N'red', N'', NULL)
SET IDENTITY_INSERT [dbo].[tbl_Calendar] OFF
SET IDENTITY_INSERT [dbo].[tbl_company_details] ON 

INSERT [dbo].[tbl_company_details] ([com_id], [com_company_name], [com_company_name2], [com_owner_name], [com_address], [com_contact], [com_gst_no], [com_email], [com_website], [com_company_logo], [com_bank_name], [com_branch], [com_acc_no], [com_ifsc], [com_company_logo2], [com_note], [com_otpno], [com_created_date], [client_id], [com_upino]) VALUES (1, N'Shagun Graphics', N'', N'Uttam Singh', N'49 Tilak Nagar 
Near BSNL Office, PALI 306401 (Rajasthan)', N'9252809480', N'08BRZPS5037E1Z5', N'shagun.us@gmail.com', N'shagungraphics.com', N'shagun_logo.png', N'ICICI BANK', N'MASTAN BABA-PALI', N'06540550655', N'ICIC0000654', N'shagun_logo.png', N'', N'', CAST(0x05440B00 AS Date), 0, N'9252809480')
SET IDENTITY_INSERT [dbo].[tbl_company_details] OFF
SET IDENTITY_INSERT [dbo].[tbl_customer] ON 

INSERT [dbo].[tbl_customer] ([c_id], [c_name], [c_address], [c_contact], [c_contact2], [c_gst_no], [c_opening_balance], [c_email], [c_dob], [c_anidate]) VALUES (2, N'Lalit Graphics ', N'JOJAWAR', N'9549596939', N'', N'', CAST(0 AS Decimal(18, 0)), N'lalitgraphicsjojawar6@gmail.com', CAST(0x5B950A00 AS Date), CAST(0x5B950A00 AS Date))
INSERT [dbo].[tbl_customer] ([c_id], [c_name], [c_address], [c_contact], [c_contact2], [c_gst_no], [c_opening_balance], [c_email], [c_dob], [c_anidate]) VALUES (3, N'VECTOR GRAPHICS', N'SOJAT ROAD', N'7737622647', N'', N'', CAST(0 AS Decimal(18, 0)), N'vectorartsod@gmail.com', CAST(0x5B950A00 AS Date), CAST(0x5B950A00 AS Date))
INSERT [dbo].[tbl_customer] ([c_id], [c_name], [c_address], [c_contact], [c_contact2], [c_gst_no], [c_opening_balance], [c_email], [c_dob], [c_anidate]) VALUES (4, N'SHREE JEE GRAPHICS', N'PALI', N'7665352518', N'', N'', CAST(0 AS Decimal(18, 0)), N'shreejigraphics26@gmail.com', CAST(0x5B950A00 AS Date), CAST(0x5B950A00 AS Date))
INSERT [dbo].[tbl_customer] ([c_id], [c_name], [c_address], [c_contact], [c_contact2], [c_gst_no], [c_opening_balance], [c_email], [c_dob], [c_anidate]) VALUES (5, N'SAMTA OFFSET', N'WHITE HOUSE, PALI', N'9414288536', N'', N'', CAST(0 AS Decimal(18, 0)), N'anandmehta21@gmail.com', CAST(0x5B950A00 AS Date), CAST(0x5B950A00 AS Date))
INSERT [dbo].[tbl_customer] ([c_id], [c_name], [c_address], [c_contact], [c_contact2], [c_gst_no], [c_opening_balance], [c_email], [c_dob], [c_anidate]) VALUES (6, N'JAYA DIGITAL ', N'NADOL', N'8432078096', N'', N'', CAST(0 AS Decimal(18, 0)), N'jayadigital891@gmail.com', CAST(0x5B950A00 AS Date), CAST(0x5B950A00 AS Date))
INSERT [dbo].[tbl_customer] ([c_id], [c_name], [c_address], [c_contact], [c_contact2], [c_gst_no], [c_opening_balance], [c_email], [c_dob], [c_anidate]) VALUES (8, N'AKSARA PRINT', N'SOMESAR', N'8094628878', N'', N'', CAST(0 AS Decimal(18, 0)), N'aksharaprintsomesar@gmail.com', CAST(0x5B950A00 AS Date), CAST(0x5B950A00 AS Date))
INSERT [dbo].[tbl_customer] ([c_id], [c_name], [c_address], [c_contact], [c_contact2], [c_gst_no], [c_opening_balance], [c_email], [c_dob], [c_anidate]) VALUES (9, N'ART PRINT', N'SOJAT CITY', N'9928246444', N'8209930566', N'', CAST(1690 AS Decimal(18, 0)), N'artsojat444@gmail.com', CAST(0x5B950A00 AS Date), CAST(0x5B950A00 AS Date))
INSERT [dbo].[tbl_customer] ([c_id], [c_name], [c_address], [c_contact], [c_contact2], [c_gst_no], [c_opening_balance], [c_email], [c_dob], [c_anidate]) VALUES (10, N'elppe chemicals pvt ltd ', N'Dhatav roha,raigad .', N'8446500503', N'', N'', CAST(15540 AS Decimal(18, 0)), N'', CAST(0x5B950A00 AS Date), CAST(0x5B950A00 AS Date))
INSERT [dbo].[tbl_customer] ([c_id], [c_name], [c_address], [c_contact], [c_contact2], [c_gst_no], [c_opening_balance], [c_email], [c_dob], [c_anidate]) VALUES (11, N'Bhavesh Wankhade', N'Sangli', N'9373832314', N'', N'', CAST(39558 AS Decimal(18, 0)), N'', CAST(0x5B950A00 AS Date), CAST(0x5B950A00 AS Date))
INSERT [dbo].[tbl_customer] ([c_id], [c_name], [c_address], [c_contact], [c_contact2], [c_gst_no], [c_opening_balance], [c_email], [c_dob], [c_anidate]) VALUES (12, N'piu ', N'katora', N'3289045558', N'1112', N'4566', CAST(2558 AS Decimal(18, 0)), N'', CAST(0x5B950A00 AS Date), CAST(0x5B950A00 AS Date))
INSERT [dbo].[tbl_customer] ([c_id], [c_name], [c_address], [c_contact], [c_contact2], [c_gst_no], [c_opening_balance], [c_email], [c_dob], [c_anidate]) VALUES (13, N'Chandrakant K', N'', N'', N'', N'', CAST(0 AS Decimal(18, 0)), N'', CAST(0x5B950A00 AS Date), CAST(0x5B950A00 AS Date))
SET IDENTITY_INSERT [dbo].[tbl_customer] OFF
INSERT [dbo].[tbl_email_config] ([ec_id], [ec_email], [ec_password], [ec_port], [ec_subject], [ec_smtp]) VALUES (1, N'Not Set', N'Not Set', N'Not Set', N'Not Set', N'Not Set')
SET IDENTITY_INSERT [dbo].[tbl_expense] ON 

INSERT [dbo].[tbl_expense] ([e_id], [e_category_name], [e_user_name], [e_amount], [e_count], [e_date], [e_desc]) VALUES (2, N'Tea Expense ', N'Mukesh Bhai', 3600, CAST(0 AS Decimal(18, 0)), CAST(0x08440B00 AS Date), N'1- Vardhman Sanitary 20x4, 4x10 =700  2- Petrol Pump Khincha 8x8=100   3- Hirajji Pump Oneway + Star 1500   4- Ajit Lodha 10x8=2, 12x3 =450   5- MBM School 6x4, 4x5, 25x3.5= 400,  Radhe Collection 10x8=2, 3x5 = 400, frame Return 20x3, 6x4 = 3600')
INSERT [dbo].[tbl_expense] ([e_id], [e_category_name], [e_user_name], [e_amount], [e_count], [e_date], [e_desc]) VALUES (3, N'Activa - Blue Petrol', N'Petrol', 200, CAST(0 AS Decimal(18, 0)), CAST(0x08440B00 AS Date), N'Mukesh')
INSERT [dbo].[tbl_expense] ([e_id], [e_category_name], [e_user_name], [e_amount], [e_count], [e_date], [e_desc]) VALUES (4, N'Lakadi Frame', N' Nadim Bhai ', 11400, CAST(0 AS Decimal(18, 0)), CAST(0x08440B00 AS Date), N'Lakadi Frame + Taxi Bhada')
INSERT [dbo].[tbl_expense] ([e_id], [e_category_name], [e_user_name], [e_amount], [e_count], [e_date], [e_desc]) VALUES (5, N'bond', N'Bond Wala', 500, CAST(0 AS Decimal(18, 0)), CAST(0x09440B00 AS Date), N'20 Bond')
INSERT [dbo].[tbl_expense] ([e_id], [e_category_name], [e_user_name], [e_amount], [e_count], [e_date], [e_desc]) VALUES (6, N'Tea Expense ', N'Tea wala ', 600, CAST(0 AS Decimal(18, 0)), CAST(0x31440B00 AS Date), N'')
INSERT [dbo].[tbl_expense] ([e_id], [e_category_name], [e_user_name], [e_amount], [e_count], [e_date], [e_desc]) VALUES (7, N'Rent', N' Nadim Bhai ', 6500, CAST(0 AS Decimal(18, 0)), CAST(0x31440B00 AS Date), N'UTR 141581654521')
SET IDENTITY_INSERT [dbo].[tbl_expense] OFF
SET IDENTITY_INSERT [dbo].[tbl_expense_category] ON 

INSERT [dbo].[tbl_expense_category] ([cat_id], [cat_category_name], [cat_date]) VALUES (1, N'Tea Expense ', CAST(0x07440B00 AS Date))
INSERT [dbo].[tbl_expense_category] ([cat_id], [cat_category_name], [cat_date]) VALUES (2, N'Banner Pasting & Fitting Labour', CAST(0x08440B00 AS Date))
INSERT [dbo].[tbl_expense_category] ([cat_id], [cat_category_name], [cat_date]) VALUES (3, N'Lakadi Frame', CAST(0x08440B00 AS Date))
INSERT [dbo].[tbl_expense_category] ([cat_id], [cat_category_name], [cat_date]) VALUES (4, N'Activa - Blue Petrol', CAST(0x08440B00 AS Date))
INSERT [dbo].[tbl_expense_category] ([cat_id], [cat_category_name], [cat_date]) VALUES (5, N'bond', CAST(0x09440B00 AS Date))
INSERT [dbo].[tbl_expense_category] ([cat_id], [cat_category_name], [cat_date]) VALUES (6, N'Rent', CAST(0x31440B00 AS Date))
SET IDENTITY_INSERT [dbo].[tbl_expense_category] OFF
SET IDENTITY_INSERT [dbo].[tbl_expense_user] ON 

INSERT [dbo].[tbl_expense_user] ([u_id], [u_user_name], [u_contact], [u_desc]) VALUES (1, N'Tea wala ', N'1234567890', N'Chaye wala')
INSERT [dbo].[tbl_expense_user] ([u_id], [u_user_name], [u_contact], [u_desc]) VALUES (2, N'Mukesh Bhai', N'9521210105', N'Banner pasting')
INSERT [dbo].[tbl_expense_user] ([u_id], [u_user_name], [u_contact], [u_desc]) VALUES (3, N' Nadim Bhai ', N'97846 66068', N'Lakadi Frame 2x3- 400 pcs.  =  8800+ Taxi Bhada 2600 = 11400')
INSERT [dbo].[tbl_expense_user] ([u_id], [u_user_name], [u_contact], [u_desc]) VALUES (4, N'Petrol', N'', N'Activa ')
INSERT [dbo].[tbl_expense_user] ([u_id], [u_user_name], [u_contact], [u_desc]) VALUES (5, N'Bond Wala', N'Pali', N'Bond Pkt.')
SET IDENTITY_INSERT [dbo].[tbl_expense_user] OFF
INSERT [dbo].[tbl_feature] ([fe_id], [fe_sms], [fe_mail], [fe_del], [fe_otp]) VALUES (1, 1, 0, 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_order] ON 

INSERT [dbo].[tbl_order] ([quw_id], [quw_no], [quw_date], [quw_total_quantity], [quw_discount], [quw_sub_total], [quw_shipping_charges], [quw_adjustment], [quw_total], [quw_name], [quw_phone], [quw_balance], [quw_dtp_charges], [quw_fitting_charges], [quw_payment_method], [quw_pasting_charges]) VALUES (1, N'CASH-1', CAST(0x07440B00 AS Date), CAST(501 AS Decimal(18, 0)), 0, 550, 30, 200, CAST(580 AS Decimal(18, 0)), N'rakesh', N'9875172000', 380, 0, 0, N'Google Pay', 0)
SET IDENTITY_INSERT [dbo].[tbl_order] OFF
SET IDENTITY_INSERT [dbo].[tbl_order_details] ON 

INSERT [dbo].[tbl_order_details] ([qw_id], [quw_no], [qw_date], [qw_product_name], [qw_quantity], [qw_total_quantity], [qw_rate], [qw_discount], [qw_sub_total], [qw_shipping_charges], [qw_adjustment], [qw_total], [qw_hsn], [qw_unit], [qw_stotal], [qw_desc], [qw_height], [qw_width], [qw_size], [qw_samount], [qw_name], [qw_phone], [qw_balance], [qw_dtp_charges], [qw_fitting_charges], [qw_payment_method], [qw_pasting_charges]) VALUES (1, N'CASH-1', CAST(0x07440B00 AS Date), N'Flex 3 Feet', CAST(1 AS Decimal(18, 0)), CAST(501 AS Decimal(18, 0)), 20, 0, 550, 30, 200, CAST(580 AS Decimal(18, 0)), N'-', N'Sqft', 250, N'star', 2.5, 5, 12.5, 250, N'rakesh', N'9875172000', 380, 0, 0, N'Google Pay', 0)
INSERT [dbo].[tbl_order_details] ([qw_id], [quw_no], [qw_date], [qw_product_name], [qw_quantity], [qw_total_quantity], [qw_rate], [qw_discount], [qw_sub_total], [qw_shipping_charges], [qw_adjustment], [qw_total], [qw_hsn], [qw_unit], [qw_stotal], [qw_desc], [qw_height], [qw_width], [qw_size], [qw_samount], [qw_name], [qw_phone], [qw_balance], [qw_dtp_charges], [qw_fitting_charges], [qw_payment_method], [qw_pasting_charges]) VALUES (2, N'CASH-1', CAST(0x07440B00 AS Date), N'Visiting Card', CAST(500 AS Decimal(18, 0)), CAST(501 AS Decimal(18, 0)), 0.6, 0, 550, 30, 200, CAST(580 AS Decimal(18, 0)), N'1245', N'Pcs', 300, N'NT Card ', 0, 0, 0, 0, N'rakesh', N'9875172000', 380, 0, 0, N'Google Pay', 0)
SET IDENTITY_INSERT [dbo].[tbl_order_details] OFF
SET IDENTITY_INSERT [dbo].[tbl_product] ON 

INSERT [dbo].[tbl_product] ([p_id], [p_name], [p_unit], [p_cgst], [p_sgst], [p_igst], [p_hsn_code], [p_rate], [p_desc]) VALUES (1, N'Flex 3 Feet', N'Sqft', N'9', N'9', N'0', N'-', 10, N'-')
INSERT [dbo].[tbl_product] ([p_id], [p_name], [p_unit], [p_cgst], [p_sgst], [p_igst], [p_hsn_code], [p_rate], [p_desc]) VALUES (2, N'Visiting Card', N'Pcs', N'9', N'9', N'0', N'1245', 0.6, N'NT Card ')
INSERT [dbo].[tbl_product] ([p_id], [p_name], [p_unit], [p_cgst], [p_sgst], [p_igst], [p_hsn_code], [p_rate], [p_desc]) VALUES (3, N'vinyal printing and sunboard ', N'Sqft', N'9', N'9', N'0', N'19682', 150, N'-')
INSERT [dbo].[tbl_product] ([p_id], [p_name], [p_unit], [p_cgst], [p_sgst], [p_igst], [p_hsn_code], [p_rate], [p_desc]) VALUES (4, N'BlackBack', N'Sqft', N'9', N'9', N'0', N'-', 22, N'-')
INSERT [dbo].[tbl_product] ([p_id], [p_name], [p_unit], [p_cgst], [p_sgst], [p_igst], [p_hsn_code], [p_rate], [p_desc]) VALUES (5, N'vinal  flex 5fit', N'Sqft', N'9', N'9', N'0', N'255836', 15, N'flex')
INSERT [dbo].[tbl_product] ([p_id], [p_name], [p_unit], [p_cgst], [p_sgst], [p_igst], [p_hsn_code], [p_rate], [p_desc]) VALUES (6, N'Flex Banner', N'Sqft', N'0', N'0', N'0', N'-', 10, N'-')
SET IDENTITY_INSERT [dbo].[tbl_product] OFF
SET IDENTITY_INSERT [dbo].[tbl_purchase_product] ON 

INSERT [dbo].[tbl_purchase_product] ([p_id], [p_name], [p_unit], [p_cgst], [p_sgst], [p_igst], [p_hsn_code], [p_rate], [p_desc], [p_stock], [p_value]) VALUES (1, N'Flex 3 Feet', N'Sqft', N'9', N'9', N'0', N'-', 10, N'-', -333, 0)
INSERT [dbo].[tbl_purchase_product] ([p_id], [p_name], [p_unit], [p_cgst], [p_sgst], [p_igst], [p_hsn_code], [p_rate], [p_desc], [p_stock], [p_value]) VALUES (2, N'Visiting Card', N'Pcs', N'9', N'9', N'0', N'1245', 0.6, N'NT Card ', -200, 0)
INSERT [dbo].[tbl_purchase_product] ([p_id], [p_name], [p_unit], [p_cgst], [p_sgst], [p_igst], [p_hsn_code], [p_rate], [p_desc], [p_stock], [p_value]) VALUES (3, N'vinyal printing and sunboard ', N'Sqft', N'9', N'9', N'0', N'19682', 150, N'-', -120, 0)
INSERT [dbo].[tbl_purchase_product] ([p_id], [p_name], [p_unit], [p_cgst], [p_sgst], [p_igst], [p_hsn_code], [p_rate], [p_desc], [p_stock], [p_value]) VALUES (4, N'BlackBack', N'Sqft', N'9', N'9', N'0', N'-', 22, N'-', 0, 0)
INSERT [dbo].[tbl_purchase_product] ([p_id], [p_name], [p_unit], [p_cgst], [p_sgst], [p_igst], [p_hsn_code], [p_rate], [p_desc], [p_stock], [p_value]) VALUES (5, N'vinal  flex 5fit', N'Sqft', N'9', N'9', N'0', N'255836', 15, N'flex', -122, 0)
INSERT [dbo].[tbl_purchase_product] ([p_id], [p_name], [p_unit], [p_cgst], [p_sgst], [p_igst], [p_hsn_code], [p_rate], [p_desc], [p_stock], [p_value]) VALUES (6, N'Flex Banner', N'Sqft', N'0', N'0', N'0', N'-', 10, N'-', 0, 0)
SET IDENTITY_INSERT [dbo].[tbl_purchase_product] OFF
SET IDENTITY_INSERT [dbo].[tbl_rate] ON 

INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (1, N'Lalit Graphics ', N'Flex 3 Feet', 20, 1)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (2, N'Lalit Graphics ', N'Visiting Card', 0.6, 1)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (5, N'ART PRINT', N'Flex 3 Feet', 10, 9)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (4, N'elppe chemicals pvt ltd ', N'vinyal printing and sunboard ', 80, 10)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (6, N'Bhavesh Wankhade', N'BlackBack', 22, 11)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (7, N'ART PRINT', N'BlackBack', 0, 9)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (1, N'Lalit Graphics ', N'Flex 3 Feet', 20, 1)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (2, N'Lalit Graphics ', N'Visiting Card', 0.6, 1)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (5, N'ART PRINT', N'Flex 3 Feet', 10, 9)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (4, N'elppe chemicals pvt ltd ', N'vinyal printing and sunboard ', 80, 10)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (6, N'Bhavesh Wankhade', N'BlackBack', 22, 11)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (7, N'ART PRINT', N'BlackBack', 0, 9)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (8, N'ART PRINT', N'BlackBack', 9, 9)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (9, N'elppe chemicals pvt ltd ', N'BlackBack', 10, 10)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (10, N'Bhavesh Wankhade', N'Flex 3 Feet', 53, 11)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (11, N'Bhavesh Wankhade', N'vinyal printing and sunboard ', 150, 11)
INSERT [dbo].[tbl_rate] ([r_id], [cust_name], [p_name], [r_rate], [c_id]) VALUES (12, N'Chandrakant K', N'Flex Banner', 9, 13)
SET IDENTITY_INSERT [dbo].[tbl_rate] OFF
SET IDENTITY_INSERT [dbo].[tbl_sale] ON 

INSERT [dbo].[tbl_sale] ([sl_id], [sl_invoice_no], [sl_date], [c_id], [sl_order_no], [sl_invoice_date], [sl_due_date], [sl_total_quantity], [sl_discount], [sl_sub_total], [sl_total_gst], [sl_shipping_charges], [sl_adjustment], [sl_total], [sl_total_cgst], [sl_total_sgst], [sl_total_igst], [sl_total_taxable], [sl_balance], [sl_dtp_charges], [sl_fitting_charges], [sl_payment_method], [sl_order_ref], [sl_transaction_type], [sl_cess], [sl_pasting_charges], [sl_framing_charges], [sl_installation_charges], [sl_upichqno]) VALUES (2, N'INV-1', CAST(0x07440B00 AS Date), 10, N'1', CAST(0x08440B00 AS Date), CAST(0x08440B00 AS Date), CAST(5 AS Decimal(18, 0)), 0, 12000, 3240, 0, 0, CAST(15540 AS Decimal(18, 0)), 1080, 1080, 1080, 12000, CAST(15540 AS Decimal(18, 0)), 300, 0, N'Cash', N'Vikram', N'Sale', 0, 0, 0, 0, N'')
INSERT [dbo].[tbl_sale] ([sl_id], [sl_invoice_no], [sl_date], [c_id], [sl_order_no], [sl_invoice_date], [sl_due_date], [sl_total_quantity], [sl_discount], [sl_sub_total], [sl_total_gst], [sl_shipping_charges], [sl_adjustment], [sl_total], [sl_total_cgst], [sl_total_sgst], [sl_total_igst], [sl_total_taxable], [sl_balance], [sl_dtp_charges], [sl_fitting_charges], [sl_payment_method], [sl_order_ref], [sl_transaction_type], [sl_cess], [sl_pasting_charges], [sl_framing_charges], [sl_installation_charges], [sl_upichqno]) VALUES (3, N'INV-2', CAST(0x08440B00 AS Date), 9, N'2', CAST(0x08440B00 AS Date), CAST(0x08440B00 AS Date), CAST(1 AS Decimal(18, 0)), 0, 150, 0, 0, 0, CAST(150 AS Decimal(18, 0)), 0, 0, 0, 150, CAST(150 AS Decimal(18, 0)), 0, 0, N'Cash', N'Vikram', N'Sale', 0, 0, 0, 0, N'')
INSERT [dbo].[tbl_sale] ([sl_id], [sl_invoice_no], [sl_date], [c_id], [sl_order_no], [sl_invoice_date], [sl_due_date], [sl_total_quantity], [sl_discount], [sl_sub_total], [sl_total_gst], [sl_shipping_charges], [sl_adjustment], [sl_total], [sl_total_cgst], [sl_total_sgst], [sl_total_igst], [sl_total_taxable], [sl_balance], [sl_dtp_charges], [sl_fitting_charges], [sl_payment_method], [sl_order_ref], [sl_transaction_type], [sl_cess], [sl_pasting_charges], [sl_framing_charges], [sl_installation_charges], [sl_upichqno]) VALUES (4, N'INV-3', CAST(0x10440B00 AS Date), 9, N'1', CAST(0x10440B00 AS Date), CAST(0x10440B00 AS Date), CAST(3 AS Decimal(18, 0)), 0, 3540, 540, 0, 2000, CAST(3540 AS Decimal(18, 0)), 270, 270, 0, 3000, CAST(1540 AS Decimal(18, 0)), 0, 0, N'Cash', N'Mana Ram', N'Sale', 0, 0, 0, 0, N'')
INSERT [dbo].[tbl_sale] ([sl_id], [sl_invoice_no], [sl_date], [c_id], [sl_order_no], [sl_invoice_date], [sl_due_date], [sl_total_quantity], [sl_discount], [sl_sub_total], [sl_total_gst], [sl_shipping_charges], [sl_adjustment], [sl_total], [sl_total_cgst], [sl_total_sgst], [sl_total_igst], [sl_total_taxable], [sl_balance], [sl_dtp_charges], [sl_fitting_charges], [sl_payment_method], [sl_order_ref], [sl_transaction_type], [sl_cess], [sl_pasting_charges], [sl_framing_charges], [sl_installation_charges], [sl_upichqno]) VALUES (5, N'INV-4', CAST(0x28440B00 AS Date), 11, N'1', CAST(0x28440B00 AS Date), CAST(0x28440B00 AS Date), CAST(9 AS Decimal(18, 0)), 0, 33100, 5958, 0, 0, CAST(39058 AS Decimal(18, 0)), 2979, 2979, 0, 33100, CAST(39058 AS Decimal(18, 0)), 0, 0, N'Cash', N'Mana Ram', N'Sale', 0, 0, 0, 0, N'')
SET IDENTITY_INSERT [dbo].[tbl_sale] OFF
SET IDENTITY_INSERT [dbo].[tbl_sale_invoice] ON 

INSERT [dbo].[tbl_sale_invoice] ([s_id], [s_invoice_no], [s_date], [c_id], [s_order_no], [s_invoice_date], [s_due_date], [s_product_name], [s_quantity], [s_total_quantity], [s_rate], [s_discount], [s_cgstp], [s_cgsta], [s_sgstp], [s_sgsta], [s_igstp], [s_igsta], [s_amount], [s_sub_total], [s_total_gst], [s_shipping_charges], [s_adjustment], [s_total], [s_stotal], [s_product_hsn], [s_unit], [s_desc], [s_height], [s_width], [s_size], [s_samount], [s_total_cgst], [s_total_sgst], [s_total_igst], [s_total_taxable], [s_balance], [s_dtp_charges], [s_fitting_charges], [s_payment_method], [s_order_ref], [s_transaction_type], [s_cess], [s_material], [s_pasting_charges], [s_framing_charges], [s_installation_charges], [s_upichqno]) VALUES (3, N'INV-1', CAST(0x07440B00 AS Date), 10, N'1', CAST(0x08440B00 AS Date), CAST(0x08440B00 AS Date), N'vinyal printing and sunboard ', CAST(5 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), 100, 0, 9, 1080, 9, 1080, 9, 1080, 15240, 12000, 3240, 0, 0, CAST(15540 AS Decimal(18, 0)), 12000, N'19682', N'Sqft', N'-', 4, 6, 24, 2400, 1080, 1080, 1080, 12000, CAST(15540 AS Decimal(18, 0)), 300, 0, N'Cash', N'Vikram', N'Sale', 0, 3, 0, 0, 0, N'')
INSERT [dbo].[tbl_sale_invoice] ([s_id], [s_invoice_no], [s_date], [c_id], [s_order_no], [s_invoice_date], [s_due_date], [s_product_name], [s_quantity], [s_total_quantity], [s_rate], [s_discount], [s_cgstp], [s_cgsta], [s_sgstp], [s_sgsta], [s_igstp], [s_igsta], [s_amount], [s_sub_total], [s_total_gst], [s_shipping_charges], [s_adjustment], [s_total], [s_stotal], [s_product_hsn], [s_unit], [s_desc], [s_height], [s_width], [s_size], [s_samount], [s_total_cgst], [s_total_sgst], [s_total_igst], [s_total_taxable], [s_balance], [s_dtp_charges], [s_fitting_charges], [s_payment_method], [s_order_ref], [s_transaction_type], [s_cess], [s_material], [s_pasting_charges], [s_framing_charges], [s_installation_charges], [s_upichqno]) VALUES (4, N'INV-2', CAST(0x08440B00 AS Date), 9, N'2', CAST(0x08440B00 AS Date), CAST(0x08440B00 AS Date), N'Flex 3 Feet', CAST(1 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), 10, 0, 0, 0, 0, 0, 0, 0, 150, 150, 0, 0, 0, CAST(150 AS Decimal(18, 0)), 150, N'-', N'Sqft', N'star', 3, 5, 15, 150, 0, 0, 0, 150, CAST(150 AS Decimal(18, 0)), 0, 0, N'Cash', N'Vikram', N'Sale', 0, 1, 0, 0, 0, N'')
INSERT [dbo].[tbl_sale_invoice] ([s_id], [s_invoice_no], [s_date], [c_id], [s_order_no], [s_invoice_date], [s_due_date], [s_product_name], [s_quantity], [s_total_quantity], [s_rate], [s_discount], [s_cgstp], [s_cgsta], [s_sgstp], [s_sgsta], [s_igstp], [s_igsta], [s_amount], [s_sub_total], [s_total_gst], [s_shipping_charges], [s_adjustment], [s_total], [s_stotal], [s_product_hsn], [s_unit], [s_desc], [s_height], [s_width], [s_size], [s_samount], [s_total_cgst], [s_total_sgst], [s_total_igst], [s_total_taxable], [s_balance], [s_dtp_charges], [s_fitting_charges], [s_payment_method], [s_order_ref], [s_transaction_type], [s_cess], [s_material], [s_pasting_charges], [s_framing_charges], [s_installation_charges], [s_upichqno]) VALUES (6, N'INV-3', CAST(0x10440B00 AS Date), 9, N'1', CAST(0x10440B00 AS Date), CAST(0x10440B00 AS Date), N'Flex 3 Feet', CAST(3 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), 10, 0, 9, 270, 9, 270, 0, 0, 3540, 3540, 540, 0, 2000, CAST(3540 AS Decimal(18, 0)), 3000, N'-', N'Sqft', N'-', 10, 10, 100, 1000, 270, 270, 0, 3000, CAST(1540 AS Decimal(18, 0)), 0, 0, N'Cash', N'--Select Designer--', N'Sale', 0, 1, 0, 0, 0, N'')
INSERT [dbo].[tbl_sale_invoice] ([s_id], [s_invoice_no], [s_date], [c_id], [s_order_no], [s_invoice_date], [s_due_date], [s_product_name], [s_quantity], [s_total_quantity], [s_rate], [s_discount], [s_cgstp], [s_cgsta], [s_sgstp], [s_sgsta], [s_igstp], [s_igsta], [s_amount], [s_sub_total], [s_total_gst], [s_shipping_charges], [s_adjustment], [s_total], [s_stotal], [s_product_hsn], [s_unit], [s_desc], [s_height], [s_width], [s_size], [s_samount], [s_total_cgst], [s_total_sgst], [s_total_igst], [s_total_taxable], [s_balance], [s_dtp_charges], [s_fitting_charges], [s_payment_method], [s_order_ref], [s_transaction_type], [s_cess], [s_material], [s_pasting_charges], [s_framing_charges], [s_installation_charges], [s_upichqno]) VALUES (7, N'INV-4', CAST(0x28440B00 AS Date), 11, N'1', CAST(0x28440B00 AS Date), CAST(0x28440B00 AS Date), N'Flex 3 Feet', CAST(2 AS Decimal(18, 0)), CAST(9 AS Decimal(18, 0)), 53, 0, 9, 238.5, 9, 238.5, 0, 0, 3127, 33100, 5958, 0, 0, CAST(39058 AS Decimal(18, 0)), 2650, N'-', N'Sqft', N'-', 5, 5, 25, 1325, 2979, 2979, 0, 33100, CAST(39058 AS Decimal(18, 0)), 0, 0, N'Cash', N'Mana Ram', N'Sale', 0, 5, 0, 0, 0, N'')
INSERT [dbo].[tbl_sale_invoice] ([s_id], [s_invoice_no], [s_date], [c_id], [s_order_no], [s_invoice_date], [s_due_date], [s_product_name], [s_quantity], [s_total_quantity], [s_rate], [s_discount], [s_cgstp], [s_cgsta], [s_sgstp], [s_sgsta], [s_igstp], [s_igsta], [s_amount], [s_sub_total], [s_total_gst], [s_shipping_charges], [s_adjustment], [s_total], [s_stotal], [s_product_hsn], [s_unit], [s_desc], [s_height], [s_width], [s_size], [s_samount], [s_total_cgst], [s_total_sgst], [s_total_igst], [s_total_taxable], [s_balance], [s_dtp_charges], [s_fitting_charges], [s_payment_method], [s_order_ref], [s_transaction_type], [s_cess], [s_material], [s_pasting_charges], [s_framing_charges], [s_installation_charges], [s_upichqno]) VALUES (8, N'INV-4', CAST(0x28440B00 AS Date), 11, N'1', CAST(0x28440B00 AS Date), CAST(0x28440B00 AS Date), N'Flex 3 Feet', CAST(3 AS Decimal(18, 0)), CAST(9 AS Decimal(18, 0)), 10, 0, 9, 40.5, 9, 40.5, 0, 0, 450, 33100, 5958, 0, 0, CAST(39058 AS Decimal(18, 0)), 450, N'-', N'Sqft', N'-', 4, 6, 24, 150, 2979, 2979, 0, 33100, CAST(39058 AS Decimal(18, 0)), 0, 0, N'Cash', N'Mana Ram', N'Sale', 0, 5, 0, 0, 0, N'')
INSERT [dbo].[tbl_sale_invoice] ([s_id], [s_invoice_no], [s_date], [c_id], [s_order_no], [s_invoice_date], [s_due_date], [s_product_name], [s_quantity], [s_total_quantity], [s_rate], [s_discount], [s_cgstp], [s_cgsta], [s_sgstp], [s_sgsta], [s_igstp], [s_igsta], [s_amount], [s_sub_total], [s_total_gst], [s_shipping_charges], [s_adjustment], [s_total], [s_stotal], [s_product_hsn], [s_unit], [s_desc], [s_height], [s_width], [s_size], [s_samount], [s_total_cgst], [s_total_sgst], [s_total_igst], [s_total_taxable], [s_balance], [s_dtp_charges], [s_fitting_charges], [s_payment_method], [s_order_ref], [s_transaction_type], [s_cess], [s_material], [s_pasting_charges], [s_framing_charges], [s_installation_charges], [s_upichqno]) VALUES (9, N'INV-4', CAST(0x28440B00 AS Date), 11, N'1', CAST(0x28440B00 AS Date), CAST(0x28440B00 AS Date), N'vinyal printing and sunboard ', CAST(4 AS Decimal(18, 0)), CAST(9 AS Decimal(18, 0)), 150, 0, 9, 2700, 9, 2700, 0, 0, 35400, 33100, 5958, 0, 0, CAST(39058 AS Decimal(18, 0)), 30000, N'19682', N'Sqft', N'-', 2, 25, 50, 7500, 2979, 2979, 0, 33100, CAST(39058 AS Decimal(18, 0)), 0, 0, N'Cash', N'Mana Ram', N'Sale', 0, 2, 0, 0, 0, N'')
SET IDENTITY_INSERT [dbo].[tbl_sale_invoice] OFF
SET IDENTITY_INSERT [dbo].[tbl_sale_invoice_payment] ON 

INSERT [dbo].[tbl_sale_invoice_payment] ([si_id], [si_invoice], [c_id], [si_due], [si_discount], [si_pay], [si_mode], [si_chno], [si_balance], [si_date], [si_upichqno]) VALUES (2, N'INV-1', 10, CAST(15540 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Cash', N'', CAST(15540 AS Decimal(18, 0)), CAST(0x07440B00 AS Date), N'')
INSERT [dbo].[tbl_sale_invoice_payment] ([si_id], [si_invoice], [c_id], [si_due], [si_discount], [si_pay], [si_mode], [si_chno], [si_balance], [si_date], [si_upichqno]) VALUES (3, N'INV-2', 9, CAST(150 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Cash', N'', CAST(150 AS Decimal(18, 0)), CAST(0x08440B00 AS Date), N'')
INSERT [dbo].[tbl_sale_invoice_payment] ([si_id], [si_invoice], [c_id], [si_due], [si_discount], [si_pay], [si_mode], [si_chno], [si_balance], [si_date], [si_upichqno]) VALUES (4, N'INV-3', 9, CAST(3540 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(2000 AS Decimal(18, 0)), N'Cash', N'', CAST(1540 AS Decimal(18, 0)), CAST(0x10440B00 AS Date), N'')
INSERT [dbo].[tbl_sale_invoice_payment] ([si_id], [si_invoice], [c_id], [si_due], [si_discount], [si_pay], [si_mode], [si_chno], [si_balance], [si_date], [si_upichqno]) VALUES (5, N'INV-4', 11, CAST(39058 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'Cash', N'', CAST(39058 AS Decimal(18, 0)), CAST(0x28440B00 AS Date), N'')
SET IDENTITY_INSERT [dbo].[tbl_sale_invoice_payment] OFF
INSERT [dbo].[tbl_sms_config] ([sc_id], [sc_key], [sc_country], [sc_sender], [sc_route]) VALUES (1, N'Not Set', 91, N'Not Set', N'Not Set')
SET IDENTITY_INSERT [dbo].[tbl_staff] ON 

INSERT [dbo].[tbl_staff] ([st_id], [st_staff_name], [st_address], [st_contact], [st_dob], [st_gender], [st_designation], [st_salary], [st_balance], [st_joining_date], [st_left_date]) VALUES (1, N'Vikram', N'Pali', N'8302849597', CAST(0xB1170B00 AS Date), N'Male', N'Operator', CAST(10000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0x02440B00 AS Date), CAST(0x5B950A00 AS Date))
INSERT [dbo].[tbl_staff] ([st_id], [st_staff_name], [st_address], [st_contact], [st_dob], [st_gender], [st_designation], [st_salary], [st_balance], [st_joining_date], [st_left_date]) VALUES (2, N'Mana Ram', N'Madari', N'9166980236', CAST(0x4C0F0B00 AS Date), N'Male', N'Labour', CAST(12000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0x02440B00 AS Date), CAST(0x1F440B00 AS Date))
SET IDENTITY_INSERT [dbo].[tbl_staff] OFF
SET IDENTITY_INSERT [dbo].[tbl_temp_sale_invoice] ON 

INSERT [dbo].[tbl_temp_sale_invoice] ([s_id], [s_invoice_no], [s_date], [c_id], [s_order_no], [s_invoice_date], [s_due_date], [s_product_name], [s_quantity], [s_total_quantity], [s_rate], [s_discount], [s_cgstp], [s_cgsta], [s_sgstp], [s_sgsta], [s_igstp], [s_igsta], [s_amount], [s_sub_total], [s_total_gst], [s_shipping_charges], [s_adjustment], [s_total], [s_stotal], [s_product_hsn], [s_unit], [s_desc], [s_height], [s_width], [s_size], [s_samount], [s_total_cgst], [s_total_sgst], [s_total_igst], [s_total_taxable], [s_balance]) VALUES (4, N'INV-1', CAST(0x07440B00 AS Date), 10, N'1', CAST(0x08440B00 AS Date), CAST(0x08440B00 AS Date), N'vinyal printing and sunboard ', CAST(5 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), 100, 0, 9, 1080, 9, 1080, 9, 1080, 15240, 12000, 3240, 0, 0, CAST(15540 AS Decimal(18, 0)), 12000, N'19682', N'Sqft', N'-', 4, 6, 24, 2400, 1080, 1080, 1080, 12000, CAST(15540 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[tbl_temp_sale_invoice] OFF
SET IDENTITY_INSERT [dbo].[tbl_used_stock] ON 

INSERT [dbo].[tbl_used_stock] ([u_id], [p_name], [date], [sqrft], [quanity]) VALUES (1, N'Flex 3 Feet', CAST(0x07440B00 AS Date), 18, 1)
INSERT [dbo].[tbl_used_stock] ([u_id], [p_name], [date], [sqrft], [quanity]) VALUES (2, N'vinyal printing and sunboard ', CAST(0x08440B00 AS Date), 120, 5)
INSERT [dbo].[tbl_used_stock] ([u_id], [p_name], [date], [sqrft], [quanity]) VALUES (3, N'Flex 3 Feet', CAST(0x08440B00 AS Date), 15, 1)
INSERT [dbo].[tbl_used_stock] ([u_id], [p_name], [date], [sqrft], [quanity]) VALUES (4, N'Flex 3 Feet', CAST(0x10440B00 AS Date), 300, 3)
INSERT [dbo].[tbl_used_stock] ([u_id], [p_name], [date], [sqrft], [quanity]) VALUES (1, N'Flex 3 Feet', CAST(0x07440B00 AS Date), 18, 1)
INSERT [dbo].[tbl_used_stock] ([u_id], [p_name], [date], [sqrft], [quanity]) VALUES (2, N'vinyal printing and sunboard ', CAST(0x08440B00 AS Date), 120, 5)
INSERT [dbo].[tbl_used_stock] ([u_id], [p_name], [date], [sqrft], [quanity]) VALUES (3, N'Flex 3 Feet', CAST(0x08440B00 AS Date), 15, 1)
INSERT [dbo].[tbl_used_stock] ([u_id], [p_name], [date], [sqrft], [quanity]) VALUES (4, N'Flex 3 Feet', CAST(0x10440B00 AS Date), 300, 3)
INSERT [dbo].[tbl_used_stock] ([u_id], [p_name], [date], [sqrft], [quanity]) VALUES (5, N'Flex 3 Feet', CAST(0x28440B00 AS Date), 50, 2)
INSERT [dbo].[tbl_used_stock] ([u_id], [p_name], [date], [sqrft], [quanity]) VALUES (6, N'Flex 3 Feet', CAST(0x28440B00 AS Date), 72, 3)
INSERT [dbo].[tbl_used_stock] ([u_id], [p_name], [date], [sqrft], [quanity]) VALUES (7, N'vinyal printing and sunboard ', CAST(0x28440B00 AS Date), 200, 4)
SET IDENTITY_INSERT [dbo].[tbl_used_stock] OFF
SET IDENTITY_INSERT [dbo].[tbl_vendor] ON 

INSERT [dbo].[tbl_vendor] ([v_id], [v_name], [v_address], [v_contact], [v_gst_no], [v_opening_balance], [v_email], [v_contact2]) VALUES (2, N'Santosh Trading Company.', N'JDOHPUR', N'8562830888', N'08AIBPA0170A1ZA', CAST(0 AS Decimal(18, 0)), N'santoshtradingcompnay@gmail.com', N'')
INSERT [dbo].[tbl_vendor] ([v_id], [v_name], [v_address], [v_contact], [v_gst_no], [v_opening_balance], [v_email], [v_contact2]) VALUES (3, N'NAKSH TRADING COMPANY', N'JODHPUR', N'9784422576', N'08CRBPP5863J1ZA', CAST(0 AS Decimal(18, 0)), N'nakshtradingjodhpur@gmail.com', N'9414122576')
INSERT [dbo].[tbl_vendor] ([v_id], [v_name], [v_address], [v_contact], [v_gst_no], [v_opening_balance], [v_email], [v_contact2]) VALUES (4, N'decora sales', N'AHEMDABAD ', N'9687647871', N'24AAGFD7696H1Z3', CAST(0 AS Decimal(18, 0)), N'info@decorasales.com', N'')
INSERT [dbo].[tbl_vendor] ([v_id], [v_name], [v_address], [v_contact], [v_gst_no], [v_opening_balance], [v_email], [v_contact2]) VALUES (5, N'PAPER CART', N'AHMEDABAD ', N'9924440879', N'24AGRPT2189E1ZZ', CAST(0 AS Decimal(18, 0)), N'papercart2015@gmail.com', N'9662069639')
INSERT [dbo].[tbl_vendor] ([v_id], [v_name], [v_address], [v_contact], [v_gst_no], [v_opening_balance], [v_email], [v_contact2]) VALUES (6, N'xyz pune', N'pune ', N'9823045552', N'112588', CAST(0 AS Decimal(18, 0)), N'xyz@gmail.com', N'566611')
SET IDENTITY_INSERT [dbo].[tbl_vendor] OFF
