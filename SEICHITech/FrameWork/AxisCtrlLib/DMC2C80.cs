using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AxisCtrlLib
{
    /// <summary>
    /// DMC2C80接口类
    /// </summary>
    public class Dmc2C80
    {
        //---------------------   板卡初始和配置函数  ----------------------
        /********************************************************************************
        ** 函数名称: d2c80_board_init
        ** 功能描述: 控制板初始化，设置初始化和速度等设置
        ** 输　  入: 无
        ** 返 回 值: 0：无卡； 1-8：成功(实际卡数)
        **
        *********************************************************************************/

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_board_init", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2c80_board_init();

        /********************************************************************************
        ** 函数名称: d2c80_board_close
        ** 功能描述: 关闭所有卡
        ** 输　  入: 无
        ** 返 回 值: 无
        ** 日    期: 2007.02.1
        *********************************************************************************/

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_board_close", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void d2c80_board_close();

        /********************************************************************************
        ** 函数名称: 控制卡复位
        ** 功能描述: 复位所有卡，只能在初始化完成之后调用．
        ** 输　  入: 卡号
        ** 返 回 值: 错误码
        ** 日    期:
        *********************************************************************************/

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_board_reset", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_board_reset(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_card_version", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_card_version(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_card_soft_version", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_card_soft_version(UInt16 card, ref UInt16 firm_id, ref UInt32 sub_firm_id);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_client_ID", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_client_ID(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_lib_version", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_lib_version();

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_card_ID", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_card_ID(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_total_axes", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_total_axes(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_test_software", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_test_software(UInt16 card, UInt16 testid, UInt16 para1, UInt16 para2, UInt16 para3);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_board_init", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_test_hardware(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_download_firmware", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_download_firmware(UInt16 card, ref char pfilename);

        //脉冲输入输出配置
        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_set_pulse_outmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_set_pulse_outmode(UInt16 axis, UInt16 outmode);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_counter_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_counter_config(UInt16 axis, UInt16 mode);

        //添加配置读
        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_pulse_outmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_pulse_outmode(UInt16 axis, ref UInt16 outmode);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_counter_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_counter_config(UInt16 axis, ref UInt16 mode);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_config_INP_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_config_INP_PIN(UInt16 axis, ref UInt16 enable, ref UInt16 inp_logic);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_config_ERC_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_config_ERC_PIN(UInt16 axis, ref UInt16 enable, ref UInt16 erc_logic,
                        ref UInt16 erc_width, ref UInt16 erc_off_time);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_config_ALM_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_config_ALM_PIN(UInt16 axis, ref UInt16 enable, ref UInt16 alm_logic, ref UInt16 alm_action);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_config_EL_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_config_EL_PIN(UInt16 axis, ref UInt16 el_logic, ref UInt16 el_mode);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_config_HOME_PIN_logic", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_config_HOME_PIN_logic(UInt16 axis, ref UInt16 org_logic, ref UInt16 filter);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_config_home_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_config_home_mode(UInt16 axis, ref UInt16 home_dir, ref double vel, ref UInt16 home_mode, ref UInt16 EZ_count);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_handwheel_inmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_handwheel_inmode(UInt16 axis, ref UInt16 inmode, ref double multi);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_config_LTC_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_config_LTC_PIN(UInt16 axis, ref UInt16 ltc_logic, ref UInt16 ltc_mode);

        //专用信号设置函数

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_config_INP_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_config_INP_PIN(UInt16 axis, UInt16 enable, UInt16 inp_logic);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_config_ERC_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_config_ERC_PIN(UInt16 axis, UInt16 enable, UInt16 erc_logic,
                        UInt16 erc_width, UInt16 erc_off_time);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_config_EMG_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_config_EMG_PIN(UInt16 cardno, UInt16 option, UInt16 emg_logic);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_config_EMG_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_config_EMG_PIN(UInt16 cardno, ref UInt16 enbale, ref UInt16 emg_logic);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_config_ALM_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_config_ALM_PIN(UInt16 axis, UInt16 enable, UInt16 alm_logic, UInt16 alm_action);

        //new

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_config_EL_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_config_EL_PIN(UInt16 axis, UInt16 el_logic, UInt16 el_mode);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_config_HOME_PIN_logic", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_config_HOME_PIN_logic(UInt16 axis, UInt16 org_logic, UInt16 filter);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_write_ERC_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_write_ERC_PIN(UInt16 axis, UInt16 sel);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_set_backlash", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_set_backlash(UInt16 axis, Int32 backlash);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_backlash", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_backlash(UInt16 axis, ref Int32 backlash);

        //通用输入/输出控制函数

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_read_inbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d2c80_read_inbit(UInt16 cardno, UInt16 bitno);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_write_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_write_outbit(UInt16 cardno, UInt16 bitno, UInt16 on_off);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_read_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d2c80_read_outbit(UInt16 cardno, UInt16 bitno);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_read_inport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2c80_read_inport(UInt16 cardno);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_read_outport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2c80_read_outport(UInt16 cardno);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_write_outport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_write_outport(UInt16 cardno, UInt32 port_value);

        //制动函数

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_decel_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_decel_stop(UInt16 axis, double dec);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_imd_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_imd_stop(UInt16 axis);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_emg_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_emg_stop();

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_simultaneous_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_simultaneous_stop(UInt16 axis);

        //位置设置和读取函数

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2c80_get_position(UInt16 axis);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_set_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_set_position(UInt16 axis, Int32 current_position);

        //状态检测函数

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_check_done", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int d2c80_check_done(UInt16 axis);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_axis_io_status", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_axis_io_status(UInt16 axis);

        //速度设置

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_read_current_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern double d2c80_read_current_speed(UInt16 axis);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_read_vector_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern double d2c80_read_vector_speed(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_change_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_change_speed(UInt16 axis, double Curr_Vel);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_set_vector_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_set_vector_profile(UInt16 cardno, double s_para, double Max_Vel, double acc, double dec);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_vector_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_vector_profile(UInt16 cardno, ref double s_para, ref double Max_Vel, ref double acc, ref double dec);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_set_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_set_profile(UInt16 axis, double option, double Max_Vel, double acc, double dec);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_set_s_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_set_s_profile(UInt16 axis, double s_para);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_profile(UInt16 axis, ref double option, ref double Max_Vel, ref double acc, ref double dec);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_s_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_s_profile(UInt16 axis, ref double s_para);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_reset_target_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_reset_target_position(UInt16 axis, Int32 dist);

        //单轴定长运动

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_pmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_pmove(UInt16 axis, Int32 Dist, UInt16 posi_mode);

        //单轴连续运动

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_vmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_vmove(UInt16 axis, UInt16 dir, double vel);

        //线性插补

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_line2", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_line2(UInt16 axis1, Int32 Dist1, UInt16 axis2, Int32 Dist2, UInt16 posi_mode);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_line3", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_line3(ref UInt16 axis, Int32 Dist1, Int32 Dist2, Int32 Dist3, UInt16 posi_mode);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_line4", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_line4(UInt16 cardno, Int32 Dist1, Int32 Dist2, Int32 Dist3, Int32 Dist4, UInt16 posi_mode);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_lineN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_lineN(UInt16 axisNum, ref UInt16 piaxisList, ref Int32 pPosList, UInt16 posi_mode);

        //手轮运动

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_set_handwheel_inmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_set_handwheel_inmode(UInt16 axis, UInt16 inmode, double multi);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_handwheel_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_handwheel_move(UInt16 axis);

        //找原点

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_config_home_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_config_home_mode(UInt16 axis, UInt16 home_dir, double vel, UInt16 mode, UInt16 EZ_count);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_home_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_home_move(UInt16 axis);

        //圆弧插补

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_arc_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_arc_move(ref UInt16 axis, ref Int32 target_pos, ref Int32 cen_pos, UInt16 arc_dir);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_rel_arc_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_rel_arc_move(ref UInt16 axis, ref Int32 rel_pos, ref Int32 rel_cen, UInt16 arc_dir);

        //设置和读取位置比较信号

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_compare_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_compare_config(UInt16 card, UInt16 enable, UInt16 axis, UInt16 cmp_source);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_compare_get_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_compare_get_config(UInt16 card, ref UInt16 enable, ref UInt16 axis, ref UInt16 cmp_source);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_compare_clear_points", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_compare_clear_points(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_compare_add_point", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_compare_add_point(UInt16 card, Int32 pos, UInt16 dir, UInt16 action, Int32 actpara);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_compare_get_current_point", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2c80_compare_get_current_point(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_compare_get_points_runned", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2c80_compare_get_points_runned(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_compare_get_points_remained", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2c80_compare_get_points_remained(UInt16 card);

        //---------------------   编码器计数功能  ----------------------//

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_encoder", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2c80_get_encoder(UInt16 axis);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_set_encoder", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_set_encoder(UInt16 axis, Int32 encoder_value);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_config_EZ_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_config_EZ_PIN(UInt16 axis, UInt16 ez_logic, UInt16 ez_mode);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_config_EZ_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_config_EZ_PIN(UInt16 axis, ref UInt16 ez_logic, ref UInt16 ez_mode);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_config_LTC_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_config_LTC_PIN(UInt16 axis, UInt16 ltc_logic, UInt16 ltc_mode);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_config_latch_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_config_latch_mode(UInt16 cardno, UInt16 all_enable);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_latch_value", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2c80_get_latch_value(UInt16 axis);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_latch_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2c80_get_latch_flag(UInt16 cardno);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_reset_latch_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_reset_latch_flag(UInt16 cardno);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_counter_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2c80_get_counter_flag(UInt16 cardno);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_reset_counter_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_reset_counter_flag(UInt16 cardno);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_reset_clear_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_reset_clear_flag(UInt16 cardno);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_triger_chunnel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_triger_chunnel(UInt16 cardno, UInt16 num);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_set_speaker_logic", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_set_speaker_logic(UInt16 cardno, UInt16 logic);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_speaker_logic", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_speaker_logic(UInt16 cardno, ref UInt16 logic);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_config_latch_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_config_latch_mode(UInt16 cardno, ref UInt16 all_enable);

        //软件限位功能

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_config_softlimit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_config_softlimit(UInt16 axis, UInt16 ON_OFF, UInt16 source_sel, UInt16 SL_action, Int32 N_limit, Int32 P_limit);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_config_softlimit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_config_softlimit(UInt16 axis, ref UInt16 ON_OFF, ref UInt16 source_sel, ref UInt16 SL_action, ref Int32 N_limit, ref Int32 P_limit);

        //连续插补函数

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_lines", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_conti_lines(UInt16 axisNum, ref UInt16 piaxisList,
            ref Int32 pPosList, UInt16 posi_mode);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_arc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_conti_arc(ref UInt16 axis, ref Int32 rel_pos, ref Int32 rel_cen, UInt16 arc_dir, UInt16 posi_mode);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_restrain_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_conti_restrain_speed(UInt16 card, double v);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_change_speed_ratio", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_conti_change_speed_ratio(UInt16 card, double percent);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_get_current_speed_ratio", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern double d2c80_conti_get_current_speed_ratio(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_set_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_conti_set_mode(UInt16 card, UInt16 conti_mode, double conti_vl, double conti_para, double filter);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_get_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_conti_get_mode(UInt16 card, ref UInt16 conti_mode, ref double conti_vl, ref double conti_para, ref double filter);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_open_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_conti_open_list(UInt16 axisNum, ref UInt16 piaxisList);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_close_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_conti_close_list(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_check_remain_space", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_conti_check_remain_space(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_decel_stop_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_conti_decel_stop_list(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_sudden_stop_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_conti_sudden_stop_list(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_pause_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_conti_pause_list(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_start_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_conti_start_list(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_read_current_mark", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 d2c80_conti_read_current_mark(UInt16 card);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_extern_lines", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_conti_extern_lines(UInt16 axisNum, ref UInt16 piaxisListw,
                                                       ref Int32 pPosList, UInt16 posi_mode, Int32 imark);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_conti_extern_arc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_conti_extern_arc(ref UInt16 axis, ref Int32 rel_pos, ref Int32 rel_cen, UInt16 arc_dir, UInt16 posi_mode, Int32 imark);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_Enable_EL_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_Enable_EL_PIN(UInt16 axis, UInt16 enable);

        [DllImport("DMC2C80.dll", EntryPoint = "d2c80_get_Enable_EL_PIN", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 d2c80_get_Enable_EL_PIN(UInt16 axis, ref UInt16 enable);

        //PC库错误码
        private enum ERR_CODE_DMC
        {
            ERR_NOERR = 0,          //成功
            ERR_UNKNOWN = 1,
            ERR_PARAERR = 2,

            ERR_TIMEOUT = 3,
            ERR_CONTROLLERBUSY = 4,
            ERR_CONNECT_TOOMANY = 5,

            ERR_CONTILINE = 40,
            ERR_CANNOT_CONNECTETH = 8,
            ERR_HANDLEERR = 9,
            ERR_SENDERR = 10,
            ERR_FIRMWAREERR = 12, //固件文件错误
            ERR_FIRMWAR_MISMATCH = 14, //固件不匹配

            ERR_FIRMWARE_INVALID_PARA = 20,  //固件参数错误
            ERR_FIRMWARE_PARA_ERR = 20,  //固件参数错误2
            ERR_FIRMWARE_STATE_ERR = 22, //固件当前状态不允许操作
            ERR_FIRMWARE_LIB_STATE_ERR = 22, //固件当前状态不允许操作2
            ERR_FIRMWARE_CARD_NOT_SUPPORT = 24,  //固件不支持的功能 控制器不支持的功能
            ERR_FIRMWARE_LIB_NOTSUPPORT = 24,    //固件不支持的功能2
        }
    }
}