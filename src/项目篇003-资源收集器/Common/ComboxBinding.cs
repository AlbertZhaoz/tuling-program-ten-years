using System;
using System.Windows.Forms;
using Sunny.UI;

namespace NET_FiveMinutes_006_AlbertToolHelperDesktop.Common
{
    public static class ComboxBinding
    {
        /// <summary>
        /// 将指定的枚举型绑定至指定的ComboBox，结果表示是否绑定成功。
        /// 用法示例：Bind<LogType>(comboBox1);
        /// </summary>
        /// <param name="cb">下拉框。</param>
        /// <param name="type">枚举类型。</param>
        /// <returns></returns>
        public static bool BindEnumToComboBox<T>(UIComboBox cb)
        {
            Type type = typeof(T);
            if (!type.IsEnum || Enum.GetValues(type).Length == 0 || cb == null)
                return false;

            cb.Items.Clear();
            foreach (var item in Enum.GetValues(type))
            {
                cb.Items.Add(item.ToString());
            }

            // 默认选择第0项。
            cb.SelectedIndex = 0;
            // 这里不是必需的，但是由于枚举型不能有额外的，所以设置为 DrawDownList.
            cb.DropDownStyle = UIDropDownStyle.DropDownList;

            return true;
        }

        /// <summary>
        /// 根据ComboBox的选定字符串，返回指定的枚举类型。如果转换失败，则返回缺少值。
        /// 用法示例：LogType lt = GetEnumFromComboBox<LogType>(comboBox1);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static T GetEnumFromComboBox<T>(UIComboBox cb)
        {
            T t = default(T); // 先初始化的默认值。
            try
            {
                t = (T)Enum.Parse(typeof(T), cb.SelectedItem.ToString()); // 进行类型转换。
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // 可以根据需要做相应的异常处理。 
            }

            return t;
        }

        /// <summary>
        /// 根据枚举型值，在ComboBox中选择相应的选项。
        /// 用法示例：SetEnumInComboBox(comboBox1, LogType.Info);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static void SetEnumInComboBox(UIComboBox cb, object value)
        {
            cb.Text = value?.ToString();
        }

        /// <summary>
        /// 将指定的枚举型绑定至指定的ComboBox，结果表示是否绑定成功。
        /// 用法示例：Bind<LogType>(comboBox1);
        /// </summary>
        /// <param name="cb">下拉框。</param>
        /// <param name="type">枚举类型。</param>
        /// <returns></returns>
        public static bool BindEnumToComboBox<T>(ComboBox cb)
        {
            Type type = typeof(T);
            if (!type.IsEnum || Enum.GetValues(type).Length == 0 || cb == null)
                return false;

            cb.Items.Clear();
            foreach (var item in Enum.GetValues(type))
            {
                cb.Items.Add(item.ToString());
            }

            // 默认选择第0项。
            cb.SelectedIndex = 0;
            // 这里不是必需的，但是由于枚举型不能有额外的，所以设置为 DrawDownList.
            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            return true;
        }

        /// <summary>
        /// 根据ComboBox的选定字符串，返回指定的枚举类型。如果转换失败，则返回缺少值。
        /// 用法示例：LogType lt = GetEnumFromComboBox<LogType>(comboBox1);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static T GetEnumFromComboBox<T>(ComboBox cb)
        {
            T t = default(T); // 先初始化的默认值。
            try
            {
                t = (T)Enum.Parse(typeof(T), cb.SelectedItem.ToString()); // 进行类型转换。
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // 可以根据需要做相应的异常处理。 
            }

            return t;
        }

        /// <summary>
        /// 根据枚举型值，在ComboBox中选择相应的选项。
        /// 用法示例：SetEnumInComboBox(comboBox1, LogType.Info);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static void SetEnumInComboBox(ComboBox cb, object value)
        {
            cb.Text = value?.ToString();
        }
    }
}
