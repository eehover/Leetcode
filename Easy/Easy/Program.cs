using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Easy
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int[] nums = new int[3] { 3, 2, 4 };
            int target = 6;
            int[] results = TwoSum_2(nums,target);
            Console.WriteLine(results[0]+" "+results[1]);*/

            /*Console.WriteLine(int.MaxValue);
            int x = 1534236469;
            int result = Reverse_1(x);
            Console.WriteLine(result);*/
            /*string s = "MCMXCVI";
            Console.WriteLine(RomanToInt(s));*/
            /*Dictionary<string, string> id2name = new Dictionary<string, string>();
            string infile_name2id = @"D:\Junyan-Pengwei\data\Project\Multiple_KGE\Xiaoice_new\Case1_15K\parallel\15K_Entityid2name.txt";
            StreamReader reader_name2id = new StreamReader(infile_name2id);
            string line_name2id = "";
            while ((line_name2id = reader_name2id.ReadLine()) != null)
            {
                string[] st = line_name2id.Split(new char[] { '\t' });
                string id = st[0];
                string name = st[1];
                if (!id2name.ContainsKey(id))
                    id2name.Add(id, name);
            }
            reader_name2id.Close();
            Console.WriteLine("id2name read finish");

            string infile= @"D:\Junyan-Pengwei\data\Project\Multiple_KGE\Xiaoice_new\entity_ranking_results.txt";
            string outfile = @"D:\Junyan-Pengwei\data\Project\Multiple_KGE\Xiaoice_new\entity_ranking_results_1.txt";
            StreamReader reader = new StreamReader(infile);
            StreamWriter writer = new StreamWriter(outfile);
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] st = line.Split(new char[] { '\t'});
                string name = id2name[st[0]];
                writer.WriteLine(name+"\t"+st[1]);
            }
            reader.Close();
            writer.Close();*/

            /*string[] st = "a".Split(new string[] {"" },StringSplitOptions.None);
            Console.WriteLine(st.Count());*/
            /*double freq = (double)74455 / ((double)74455 + (double)17451);
            Console.WriteLine(freq);

            double z1 = -0.3;//-0.0005;
            int count = 0;
            for (int n = 0; n < 5000; n++)
            {
                Random ran = new Random();
                double[] a = new double[2];
                double[] b = new double[2];
                double[] c = new double[2];

                a[0] = ran.Next(-999, 999);
                a[1] = ran.Next(-999, 999);
                b[0] = ran.Next(-999, 999);
                b[1] = ran.Next(-999, 999);
                c[0] = ran.Next(-999, 999);
                c[1] = ran.Next(-999, 999);

                //double freq_ab = Math.Exp(74455) / (Math.Exp(74455) + Math.Exp(17451));//74455;
                //double freq_ac = Math.Exp(74455) / (Math.Exp(74455) + Math.Exp(17451));
                double freq_ab = (double)74455 / ((double)74455 + (double)17451);
                double freq_ac = (double)17451 / ((double)74455 + (double)17451);

                for (int epoch = 0; epoch < 2000; epoch++)
                {
                    
                    for (int i = 0; i < 2; i++)
                    {
                        double x1 = 2 * (a[i] - b[i]);
                        x1 = freq_ab * sign(x1);
                        a[i] += z1 * x1;
                        b[i] += -z1 * x1;
                    }


                    for (int i = 0; i < 2; i++)
                    {
                        double x1 = 2 * (a[i] - c[i]);
                        x1 = freq_ac * sign(x1);
                        a[i] += z1 * x1;
                        c[i] += -z1 * x1;
                    }
                }

                double ab = l1(a, b);
                double ac = l1(a, c);
                //Console.WriteLine("ab: " + ab);
                //Console.WriteLine("ac: " + ac);
                if (ab > ac)
                {
                    //Console.WriteLine("ab: " + ab);
                    //Console.WriteLine("ac: " + ac);
                    //Console.WriteLine();
                    count++;
                }
            }
            Console.WriteLine(count);*/

            /*int[] nums1 = new int[9] {3, 4, 8,7,0,0,0,0,0 };
            int[] nums2 = new int[5] {1,2,2,3,5 };
            Merge(nums1, 4, nums2, 5);
            Console.WriteLine(string.Join(" ",nums1));*/
            Console.WriteLine(int.MaxValue);
            Console.WriteLine(int.MinValue);
            long answer = 0;
            if (answer < int.MinValue)
            {
            }

        }

        static public double l1(double[] h, double[] t)
        {
            double score = 0;
            double[] score_list = new double[h.Count()];
            Parallel.For(0, h.Count(), (i) => {
                score_list[i] = Math.Abs(h[i] - t[i]);
            });
            score = score_list.Sum();
            return score;
        }

        static public int sign(double x)
        {
            if (x < 0)
                return -1;
            else if (x > 0)
                return 1;
            else
                return 0;
        }
        //1 O[n*(n-1)]
        static public int[] TwoSum_1(int[] nums, int target)
        {
            int[] results = new int[2];
            for (int i = 0; i < (nums.Count() - 1); i++)
            {

                for (int j = (i + 1); j < nums.Count(); j++)
                {
                    if ((nums[i] + nums[j]) == target)
                    {
                        results[0] = i;
                        results[1] = j;
                        break;
                    }
                }
            }
            return results;
        }

        //1 O[n]
        static public int[] TwoSum_2(int[] nums, int target)
        {
            Dictionary<int, int> num2id = new Dictionary<int, int>();
            for (int i = 0; i < nums.Count(); i++)
            {
                if (!num2id.ContainsKey(nums[i]))
                    num2id.Add(nums[i], i);
            }


            for (int i = 0; i < nums.Count(); i++)
            {
                int remainer = target - nums[i];
                if (num2id.ContainsKey(remainer))
                {
                    if (i != num2id[remainer])
                        return (new int[] { i, num2id[remainer] });

                }
            }
            return new int[] { 0, 0 };
        }

        //7 O[n]
        static public int Reverse_1(int x)
        {
            if (x > int.MaxValue)
                return 0;
            else
            {
                string x_string = x.ToString();
                if (x_string[0] == ('-'))
                {
                    List<string> result_list = new List<string>();
                    for (int i = x_string.Length - 1; i > 0; i--)
                    {
                        result_list.Add(x_string[i].ToString());
                    }
                    try
                    {
                        return (int.Parse("-" + string.Join("", result_list)));
                    }
                    catch (OverflowException e)
                    {
                        return 0;
                    }
                }
                else
                {
                    List<string> result_list = new List<string>();
                    for (int i = x_string.Length - 1; i >= 0; i--)
                    {
                        result_list.Add(x_string[i].ToString());
                    }
                    try
                    {
                        return (int.Parse(string.Join("", result_list)));
                    }

                    catch (OverflowException e)
                    {
                        return 0;
                    }
                }
            }
        }

        //7 O[n] interesting
        static public int Reverse_2(int x)
        {
            bool flag = false;
            if (x < 0)
            {
                x = -x;
                flag = true;
            }
            long result = 0;
            while (x > 0)
            {
                int res = x % 10;
                x = x / 10;
                result = result * 10 + res;
            }
            if (result > int.MaxValue)
            {
                return 0;
            }
            else
            {
                int results = (int)result;
                if (flag)
                {
                    return (-1) * results;
                }
                else
                {
                    return results;
                }
            }
           
        }


        //9 O[n]
        static public bool IsPalindrome(int x)
        {
            int a = x;
            if (x < 0)
            {
                return false;
            }
            long result = 0;
            while (x > 0)
            {
                int res = x % 10;
                x = x / 10;
                result = result * 10 + res;
            }

            if ((long)a == result)
                return true;
            else
                return false;
        }


        //13
        static public int RomanToInt(string s)
        {
            Dictionary<char, int> roman2value = new Dictionary<char, int>();
            roman2value.Add('I', 1);
            roman2value.Add('V', 5);
            roman2value.Add('X', 10);
            roman2value.Add('L', 50);
            roman2value.Add('C', 100);
            roman2value.Add('D', 500);
            roman2value.Add('M', 1000);

            int sum = 0;
            for (int i = 0; i < s.Count(); i++)
            {
                int j = 0;
                for (j = (i + 1); j < s.Count(); j++)
                {
                    if (s[j] != s[i])
                    {
                        break;
                    }
                }
                //j=j-1;
                if (j >= s.Count())
                {
                    sum += roman2value[s[i]];
                    continue;
                }
                if (i == (j - 1))
                {
                    int now_value = roman2value[s[i]];
                    int next_value = roman2value[s[j]];
                    if (now_value < next_value)
                    {
                        sum += (next_value - now_value);
                        i = j;
                    }
                    else
                    {
                        if ((j + 1) < s.Count())
                        {
                            int next_next_value = roman2value[s[j + 1]];
                            if (next_value <= next_next_value)
                            {
                                sum += roman2value[s[i]];
                                continue;
                            }
                            else
                            {
                                sum += (now_value + next_value);
                                i = j;
                            }
                        }
                        else
                        {
                            sum += (now_value + next_value);
                            i = j;
                        }
                    }
                    
                }
                else
                {
                    int score_temp = roman2value[s[i]] * (j - i);
                    sum += score_temp;
                    i = (j - 1);
                }
            }
            return sum;
        }

        //14 O[n*m]  
        static public string LongestCommonPrefix_1(string[] strs)
        {

            if (strs.Count() > 1)
            {
                int index = 0;
                List<char> char_list = new List<char>();
                while (true)
                {
                    bool flag = true;
                    if (strs[0].Count() == index)
                    {
                        flag = false;
                        break;
                    }

                    char first_char = strs[0][index];

                    char each_char = ' ';
                    for (int i = 1; i < strs.Count(); i++)
                    {
                        if (strs[i].Count() == index)
                        {
                            flag = false;
                            break;
                        }
                        each_char = strs[i][index];
                        if (first_char != each_char)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        char_list.Add(each_char);
                    }
                    else
                    {
                        break;
                    }
                    index++;
                }
                return string.Join("", char_list);
            }
            else if (strs.Count() == 1)
                return strs[0];
            else
                return "";

        }

        //14 O[n*m] simple
        static public string LongestCommonPrefix_2(string[] strs)
        {

            if (strs.Count() == 0)
            {
                return "";
            }
            int commonlength = strs[0].Length;
            for (int i = 1; i < strs.Count(); i++)
            {
                int newcommonlength = 0;
                for (; newcommonlength < commonlength; newcommonlength++)
                {
                    if (newcommonlength >= strs[i].Length)
                    {
                        newcommonlength = strs[i].Length;
                        break;
                    }
                    if (strs[0][newcommonlength] != strs[i][newcommonlength])
                    {
                        break;
                    }
                }
                commonlength = newcommonlength;
            }
            return strs[0].Substring(0, commonlength);
        }

        //53 
        static public int MaxSubArray_1(int[] nums)
        {
            bool flag = true;
            int max_value = -int.MaxValue;
            int max_sum = -int.MaxValue;
            for (int i = 0; i < nums.Count(); i++)
            {
                if (nums[i] <= 0)
                {
                    if (nums[i] > max_value)
                        max_value = nums[i];
                    continue;
                }
                int temp_sum = 0;
                temp_sum += nums[i];
                if (max_sum < temp_sum)
                    max_sum = temp_sum;

                flag = false;
                int sub_sum = 0;

                for (int j = (i + 1); j < nums.Count(); j++)
                {
                    temp_sum += nums[j];
                    if (max_sum < temp_sum)
                        max_sum = temp_sum;

                    sub_sum += nums[j];
                    if ((nums[i] + sub_sum) <= 0)
                        break;
                }

            }
            if (flag)
            {
                return max_value;
            }
            else
            {
                return max_sum;
            }
        }

        //53 simple (need write again)
        static public int MaxSubArray_2(int[] nums)
        {
            int answer = nums[0];
            int current_sum = answer > 0 ? nums[0] : 0;
            for (int i = 1; i < nums.Count(); i++)
            {
                current_sum += nums[i];
                answer = Math.Max(answer, current_sum);
                if (current_sum <= 0)
                    current_sum = 0;
            }
            return answer;
        }

        //20 Valid Parentheses
        static public bool IsValid_1(string s)
        {
            List<char> stack = new List<char>();
            bool flag = false;
            foreach (char term in s)
            {
                if ((term == '(') || (term == '[') || (term == '{'))
                {
                    stack.Add(term);
                    flag = false;
                }
                else
                {
                    if ((stack.Count() != 0))
                    {
                        int length = stack.Count();
                        switch (term)
                        {
                            case ')':
                                if (stack[length - 1] == '(')
                                {
                                    stack.RemoveAt(length - 1);
                                    flag = true;
                                }
                                else
                                    flag = false;
                                break;
                            case '}':
                                if (stack[length - 1] == '{')
                                {
                                    stack.RemoveAt(length - 1);
                                    flag = true;
                                }
                                else
                                    flag = false;
                                break;
                            case ']':
                                if (stack[length - 1] == '[')
                                {
                                    stack.RemoveAt(length - 1);
                                    flag = true;
                                }
                                else
                                    flag = false;
                                break;
                        }
                        if (flag == false)
                            break;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }

                }
            }

            if (flag)
            {
                if (stack.Count() != 0)
                    return false;
            }

            return flag;
        }

        ///20 Valid Parentheses (more simple)
        /// note: use stack rewrite
        static public bool IsValid_2(string s)
        {
            List<char> stack = new List<char>();
            foreach (char term in s)
            {
                if ((term == '(') || (term == '[') || (term == '{'))
                    stack.Add(term);
                else
                {
                    if ((stack.Count() != 0))
                    {
                        int length = stack.Count();
                        if ((term == ')') && (stack[length - 1] != '(')) return false;
                        if ((term == ']') && (stack[length - 1] != '[')) return false;
                        if ((term == '}') && (stack[length - 1] != '{')) return false;
                        stack.RemoveAt(length - 1);
                    }
                    else
                    {
                        return false;
                    }

                }
            }

            if (stack.Count() == 0)
                return true;
            else
                return false;
        }

        //21 Merge Two Sorted Lists (need write again) linked list
        //helper: 头节点
        //pre:l1的上一个节点
        static public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode helper = new ListNode(0);
            helper.next = l1;
            ListNode pre = helper;
            while ((l1 != null) && (l2 != null))
            {
                if (l1.val < l2.val)
                {
                    l1 = l1.next;
                }
                else
                {
                    ListNode Next = l2.next;
                    pre.next = l2;
                    l2.next = l1;
                    l2 = Next;
                }
                pre = pre.next;
            }

            if (l2 != null)
            {
                pre.next = l2;
            }
            return helper.next;
        }

        //26 Remove Duplicates from Sorted Array
        static public int RemoveDuplicates_1(int[] nums)
        {
            if (nums.Count() == 0)
                return 0;
            else
            {
                int pre = nums[0];
                int length = 1;
                for (int i = 1; i < nums.Count(); i++)
                {
                    if (nums[i] == pre)
                    {

                    }
                    else
                    {
                        if (length != i)
                            nums[length] = nums[i];
                        pre = nums[i];

                        length++;
                    }
                }
                return length;
            }
        }

        //27 Remove Element
        static public int RemoveElement(int[] nums, int val)
        {
            if (nums.Count() == 0)
                return 0;
            else
            {
                int length = 0;
                for (int i = 0; i < nums.Count(); i++)
                {
                    if (nums[i] != val)
                    {
                        if (length != i)
                            nums[length] = nums[i];
                        length++;
                    }
                }
                return length;
            }
        }

        //28 Implement strStr() note!!!!!!!!!!!!!!!!!!!!
        static public int StrStr_1(string haystack, string needle)
        {
            if (!haystack.Contains(needle))
                return -1;
            else if (needle == "") // note this place
                return 0;
            else
            {
                string[] st = haystack.Split(new string[] { needle},StringSplitOptions.None);
                return st[0].Length;
            }
        }

        //28 Implement strStr() 
        static public int StrStr_2(string haystack, string needle)
        {
            if (needle == "")
                return 0;
            else
            {
                for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
                {
                    for (int j = 0; j < needle.Length; j++)
                    {
                        if (haystack[i + j] == needle[j])
                        {
                            if (j == (needle.Length - 1))
                                return i;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                return -1;
            }
        }

        //35. Search Insert Position
        static public int SearchInsert_1(int[] nums, int target)
        {
            for (int i = 0; i < nums.Count(); i++)
            {
                if (target == nums[i])
                {
                    return i;
                }
                else
                {
                    if (i == 0)
                    {
                        if (target < nums[i])
                            return 0;
                    }
                    else
                    {
                        if (!((target < nums[i]) && (target > nums[i - 1])))
                        {
                            continue;
                        }
                        else
                        {
                            return i;
                        }

                    }

                }
            }
            return nums.Count();
        }

        //35. Search Insert Position
        static public int SearchInsert_2(int[] A, int target)
        {
            
            if (A.Length == 0)
            {
                return 0;
            }
            int l = 0;
            int r = A.Length - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (A[mid] == target)
                    return mid;
                if (A[mid] < target)
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            return l; // or return r+1;
        }

        //38. Count and Say
        static public string CountAndSay_1(int n)
        {
            if (n == 1)
            {
                return "1";
            }
            else
            {
                string temp = "1";
                string result = "";
                for (int i = 2; i <= n; i++) //note: i start from 2 not 1!!!!!!!!!!!
                {
                    result = calculate_next_1(temp);
                    temp = result;
                }
                return result;
            }
        }

        static public string calculate_next_1(string input)
        {
            if (input.Length == 1)
            {
                int num = int.Parse(input);
                return "1" + num.ToString();
            }
            int index_pre = 0;
            char pre = input[index_pre];
            string result = "";
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == pre)
                {
                    continue;
                }
                else
                {
                    int sub = i - index_pre;
                    result += sub.ToString() + pre.ToString();
                    index_pre = i;
                    pre = input[i];
                }
            }
            int sub_ = input.Length - index_pre;
            result += sub_.ToString() + pre.ToString();
            return result;
        }

        //38. Count and Say (more simple)
        static public string CountAndSay_2(int n)
        {
            if (n == 1)
            {
                return "1";
            }
            else
            {
                string temp = "1";
                string result = "";
                for (int i = 2; i <= n; i++)
                {
                    result = calculate_next_2(temp);
                    temp = result;
                }
                return result;
            }
        }

        static public string calculate_next_2(string input)
        {
            int read = 0;
            StringBuilder sb = new StringBuilder();
            while (read < input.Length)
            {
                char current_value = input[read];
                int next_read = read + 1;
                while ((next_read < input.Length) && (input[next_read] == current_value))
                {
                    next_read++;
                }
                int sub = next_read - read;
                sb.Append(sub.ToString() + current_value.ToString());
                read = next_read;
            }
            return sb.ToString();
        }

        //58 Length of Last Word
        static public int LengthOfLastWord_1(string s) //use high level inner function //note s would contain many space at last
        {
            if (s == "")
                return 0;
            s = s.Trim();
            string[] st = s.Split(new char[] { ' ' });
            if (st[st.Count() - 1] == "")
                return 0;
            else
                return st[st.Count() - 1].Count();
        }

        //58. Length of Last Word 
        //use ordinary operation
        //note s would contain many space at last
        static public int LengthOfLastWord_2(string s)
        {
            if (s == "")
                return 0;
            int right = s.Length - 1;
            while ((right >= 0) && (s[right] == ' '))   //note: string cannot equal to char s[right]==""(wrong)
                right--;

            int end = right;
            for (; right >= 0; right--) //note: the first item of for should not be "right" 
            {
                if (s[right] == ' ')
                {
                    return (end - right);
                }
            }

            return (end - right);
        }

        //67. Add Binary
        //need rewrite, do the sample code if have time
        static public string AddBinary(string a, string b)
        {

            int length = Math.Max(a.Length, b.Length);
            if (a.Length < length)
            {
                a = (new string('0', length - a.Length)) + a;
            }
            else
            {
                b = (new string('0', length - b.Length)) + b;
            }

            int pre = 0;
            int[] c = new int[length + 1];
            for (int i = length - 1; i >= 0; i--)
            {
                int a_num = int.Parse(a[i].ToString());
                int b_num = int.Parse(b[i].ToString());
                if ((a_num + b_num + pre) >= 2)
                {
                    c[i + 1] = ((a_num + b_num + pre) - 2);//(a[i]-'0') + (b[i] - '0') + carry; if directly use char type
                    pre = 1;
                }
                else
                {
                    c[i + 1] = (a_num + b_num + pre);
                    pre = 0;
                }
            }

            if (pre == 1)
            {
                c[0] = 1;
            }

            //note: this place is easy to make error, we can only remove one '0' if meet!!!
            string result = string.Join("", c);
            if (result.Count() > 1)
            {
                if (result[0] == '0')
                    result = result.Substring(1, result.Count() - 1);  // note: Substring not SubString!!!
            }
            return result;
        }

        //69. Sqrt(x)
        //binary search -- slow
        static public int sqrt_1(int x)
        {
            ulong begin = 0;
            ulong end = ((ulong)x + 1) / 2;
            ulong mid;
            ulong temp; //must use ulong, otherwise would exceed the max value of int
            while (begin <= end)
            {
                mid = (begin + end) / 2;
                temp = mid * mid;
                if (temp == (ulong)x)
                    return (int)mid;
                else if (temp < (ulong)x)
                {
                    begin = mid + 1;
                }
                else
                    end = mid - 1;
            }
            return (int)(begin-1);
        }

        //69. Sqrt(x)
        //newton method -- fast
        static public int sqrt_2(int x)
        {
            if (x == 0)
                return 0;
            double pre;
            double cur = 1;
            do
            {
                pre = cur;
                cur = (pre + x / (pre)) / 2.0; //x_{i+1}=(x_i+n/x_i)/2
            } while (Math.Abs(pre-cur)>0.00001);
            return (int)cur;
        }

        //70. Climbing Stairs
        //note: dp method
        static public int ClimbStairs(int n)
        {
            int pre_2 = 0;
            int pre_1 = 1;
            int cur = 0;
            for (int i = 1; i <= n; i++)
            {
                cur = pre_1 + pre_2;               
                pre_2 = pre_1; //note: cann't reverse the following two sentences
                pre_1 = cur;
                
                
            }
            return cur;
        }

        //83. Remove Duplicates from Sorted List
        //note: the input head may be null
        static public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) //note: the input head may be null
                return null;
            ListNode helper = new ListNode(0);
            ListNode pre = head;
            helper.next = pre;

            while ((head.next != null))
            {
                head = head.next;
                if (head.val == pre.val)
                {
                    continue;
                }
                else
                {
                    pre.next = head;
                    pre = head;
                }
            }
            pre.next = null;
            return helper.next;

        }


        //88. Merge Sorted Array
        //note: must loop the two array from end to start
        static public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int k = m + n - 1;
            int i = m - 1;
            int j = n - 1;
            while ((i >= 0) && (j >= 0))
            {
                if (nums1[i] >= nums2[j])
                {
                    nums1[k] = nums1[i];
                    k--;
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    k--;
                    j--;
                }
            }

            while (j >= 0)
            {
                nums1[k] = nums2[j];
                k--;
                j--;
            }

        }

        //not leetcode topic
        /*static public int x2y2n(int n)
        {
            Dictionary<int, int> square2index = new Dictionary<int, int>();
            for (int i = 0; i <= n; i++)
            {
                int square = i * i;
                if (square >= n)
                    break;
                if (!square2index.ContainsKey(square))
                    square2index.Add(square,i);
            }

            for (int x = 0; x <= n; x++)
            {
                int square = x * x;
                if (square >= n)
                    break;
                int square_y = n - square;
            }

        }*/

    }

    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }
}
