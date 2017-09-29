using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Medium
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abcdefghijklmnopqrstuvwxyz";

            /*string result = Convert(s, 8);
            Console.WriteLine("==");
            Console.WriteLine(result);
            string outfile = @"D:\Junyan-Pengwei\code\Project\Leetcode\Medium\test.txt";
            StreamWriter writer = new StreamWriter(outfile);
            writer.WriteLine(result);
            writer.Close();*/
            /*int[] input = new int[] { 2,3,6,7};
            IList<IList<int>> result = CombinationSum(input,7);
            foreach (List<int> term in result)
            {
                Console.WriteLine(string.Join(",",term));
            }*/
            //Console.WriteLine(long.MaxValue);
            /*Stopwatch sw = new Stopwatch();
            sw.Start();
            double x = 0.00001;
            int n = 2147483647;
            double result=MyPow(x,n);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds.ToString());
            Console.WriteLine(result);*/

            Console.WriteLine(int.MaxValue);
            Console.WriteLine(int.MinValue);

        }

        static public void test(Queue<int> stack)
        {
            stack.Enqueue(3);
        }

        //2. Add Two Numbers -- ListNode a little complex
        static public ListNode AddTwoNumbers_1(ListNode l1, ListNode l2)
        {
            ListNode helper = new ListNode(0);
            helper.next = l1;

            int carry = 0;
            ListNode pre = new ListNode(0);
            while ((l1 != null))
            {
                int num;
                if (l2 != null)
                    num = l1.val + l2.val + carry;
                else
                    num = l1.val + carry;
                if (num >= 10)
                {
                    num = num - 10;
                    carry = 1;
                    l1.val = num;
                }
                else
                {
                    carry = 0;
                    l1.val = num;
                }
                pre = l1;
                l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;

            }

            while (l2 != null)
            {
                pre.next = l2;
                int num = l2.val + carry;
                if (num >= 10)
                {
                    num = num - 10;
                    carry = 1;
                    l2.val = num;
                }
                else
                {
                    carry = 0;
                    l2.val = num;
                }
                pre = l2;
                l2 = l2.next;
            }


            if ((l1 == null) && (l2 == null) && (carry == 1))
            {
                ListNode last = new ListNode(1);
                pre.next = last;
            }


            return helper.next;
        }

        //2. Add Two Numbers -- ListNode simple note:easy
        static public ListNode AddTwoNumbers_2(ListNode l1, ListNode l2)
        {
            ListNode help = new ListNode(0);
            ListNode temp = help;
            int carry = 0;
            while ((carry != 0) || (l1 != null) || (l2 != null))
            {
                int num = carry + (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val);
                carry = num / 10;
                num = num % 10;
                temp.next = new ListNode(num);
                temp = temp.next;
                l1 = (l1 == null) ? null : l1.next;
                l2 = (l2 == null) ? null : l2.next;
            }

            return help.next;
        }

        //3. Longest Substring Without Repeating Characters note: rewrite
        static public int LengthOfLongestSubstring(string s)
        {
            if ((s == null) || (s == ""))
                return 0;
            int max_len = 1;
            for (int j = 0; j < s.Length; j++)
            {
                char pre_char = s[j];
                //int temp=1;
                Dictionary<char, int> temp2index = new Dictionary<char, int>();
                temp2index.Add(pre_char, j);
                for (int i = (j + 1); i < s.Length; i++)
                {
                    if (s[i] == pre_char)
                    {
                        j = i - 1;
                        break;
                    }
                    pre_char = ' ';
                    if (!temp2index.ContainsKey(s[i]))
                    {
                        temp2index.Add(s[i], i);
                        max_len = (max_len < temp2index.Count() ? temp2index.Count() : max_len);
                    }
                    else
                    {
                        int index = temp2index[s[i]];
                        j = index;
                        max_len = (max_len < temp2index.Count() ? temp2index.Count() : max_len);
                        break;
                    }
                }
            }

            return max_len;
        }


        //5. Longest Palindromic Substring -- most simple o[n*n] note:rewrite
        public string LongestPalindrome_1(string s)
        {
            int max_len = 0;
            string result = "";
            for (int i = 0; i < s.Length - 1; i++)
            {
                string temp = "";
                if (s[i] == s[i + 1])
                {
                    temp = LongestPalindrome(i - 1, i + 2, s);

                }
                if (max_len < temp.Length)
                {
                    max_len = temp.Length;
                    result = temp;
                }
                temp = LongestPalindrome(i - 1, i + 1, s); //note: we must search odd number each number

                if (max_len < temp.Length)
                {
                    max_len = temp.Length;
                    result = temp;
                }
            }

            if (result == "") //note: input may be one char.
            {
                result = s;
            }
            return result;
        }
        public string LongestPalindrome(int left, int right, string s)
        {
            if (left < 0) //note
            {
                return s.Substring(left + 1, right);
            }


            while ((left >= 0) && (right < s.Length))
            {
                if (s[left] != s[right])
                {
                    break;
                }
                else
                {
                    left--;
                    right++;
                }
            }

            string result = s.Substring(left + 1, right - 1 - (left + 1) + 1);
            return result;
        }

        //5. Longest Palindromic Substring -- DP O[n*n] -- not valid Memory Limit Exceeded 
        static public string LongestPalindrome_2(string s)
        {
            /*int max_len = 0;
            string result = "";
            int[,] result_array = new int[s.Length, s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j <=i; j++)
                {
                    if (j == i)
                    {

                        result_array[j, i] = 1;
                        if (max_len < (i -j  + 1))
                        {
                            max_len = (i - j + 1);
                            result = s.Substring(j, i - j + 1);
                        }
                    }
                    else if (i == (j + 1))
                    {
                        if (s[i] == s[j])
                        {
                            result_array[j, i] = 1;
                            if (max_len < (i - j + 1))
                            {
                                max_len = (i - j + 1);
                                result = s.Substring(j, i - j + 1);
                            }
                        }
                    }
                    else
                    {
                        if ((s[i] == s[j]) && (result_array[j+1, i-1] == 1))
                        {
                            result_array[j,i] = 1;
                            if (max_len < (i - j + 1))
                            {
                                max_len = (i - j + 1);
                                result = s.Substring(j, i - j + 1);
                            }
                        }
                    }
                }
            }
            return result;*/

            int[,] dp = new int[s.Length, s.Length];
            int left = 0, right = 0, len = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if ((s[i] == s[j]) && (i - j < 2 || (dp[j + 1, i - 1] == 1)))
                        dp[j, i] = 1;
                    if ((dp[j,i]==1) && (len < i - j + 1))
                    {
                        len = i - j + 1;
                        left = j;
                        right = i;
                    }
                }
                dp[i,i] = 1;
            }
            return s.Substring(left, right - left + 1);
        }

        //6. ZigZag Conversion cost too much time
        static public string Convert_1(string s, int numRows)
        {
            List<string[]> result_list = new List<string[]>();  
            for (int i = 0; i < s.Length; i=i+2*numRows-2)
            {
                string[] temp_list = new string[numRows];
                
                for (int j = i; j < i + 2 * numRows - 2; j++)
                {
                    if (j >= s.Length)
                        break;
                    int mod = j % (2 * numRows - 2);
                    if (j < i + numRows)
                    {
                        temp_list[mod] = s[j].ToString();
                        if ((j == (i + numRows - 1))||(j== s.Length-1)) //note the j==s.Length-1
                        {
                            result_list.Add(temp_list);
                            temp_list = new string[numRows];
                        }
                    }
                    else
                    {
                        temp_list[2 * numRows - 2-mod]= s[j].ToString();
                        result_list.Add(temp_list);
                        temp_list = new string[numRows];
                    }
                }
            }
            List<string> result = new List<string>();
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < result_list.Count(); j++)
                {
                 if(result_list[j][i]!="")   
                    result.Add(result_list[j][i]);
                   //Console.Write(result_list[j][i]);
                }
                //Console.WriteLine();
            }
           
            return string.Join("", result);
        }

        //6. ZigZag Conversion note: rewrite
        static public string Convert_2(string s, int numRows)
        {
            if (numRows == 1) //note: the unmrows may be 1
                return s;

            int interval = 2 * numRows - 2;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numRows; i++)
            {
                int ano = interval - i;
                for (int j = 0; j < s.Length; j++)
                {
                    if ((j % interval == i)||(j%interval== ano))
                    {
                        sb.Append(s[j]);
                    }
                }
            }
            return sb.ToString();
        }

        //8. String to Integer (atoi) note: reconsider all of the conditions
        static public int MyAtoi(string str)
        {
            bool start = false;
            List<int> result_list = new List<int>();
            bool neg = false;
            long result = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (((str[i] == ' ') || (str[i] == '\t')) && (start == false)) //note: start == false condition
                {
                    continue;
                }

                if (((str[i] == '-') || (str[i] == '+')) && (start == false)) //note: start == false condition
                {
                    if (str[i] == '-')
                        neg = true;
                    start = true;
                    continue;
                }

                if ((str[i] >= 48) && (str[i] <= 57))
                {
                    result = (result * 10 + str[i] - 48);
                    if (result > int.MaxValue) //note: overflow
                    {
                        return neg ? int.MinValue : int.MaxValue;
                    }

                    start = true;
                }
                else
                    break;

            }
            return neg ? (int)(-result) : (int)result;

        }

        //11. Container With Most Water note: o[n] -- great
        static public int MaxArea(int[] height)
        {
            int max_area = 0;
            for (int i = 0, j = height.Count() - 1; i < j;)
            {
                int min_index_height = Math.Min(height[i], height[j]);
                int area = min_index_height * (j - i);
                max_area = area > max_area ? area : max_area;
                if (height[i] < height[j])
                {
                    i++;
                }
                else
                    j--;
            }
            return max_area;
        }

        //15. 3Sum O(n*n) Runtime Error 
        public IList<IList<int>> ThreeSum_1(int[] nums)
        {
            nums = nums.OrderBy(n => n).ToArray(); //note
            Dictionary<int, List<int>> value2indexlist = new Dictionary<int, List<int>>();
            int index = 0;
            foreach (int item in nums)
            {
                if (!value2indexlist.ContainsKey(item))
                {
                    List<int> temp = new List<int>();
                    temp.Add(index);
                    value2indexlist.Add(item, temp);
                }
                else
                {
                    List<int> temp = value2indexlist[item];
                    temp.Add(index);
                    value2indexlist[item] = temp;
                }
                index++;
            }

            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < nums.Count() - 1; i++)
            {
                if ((i > 0) && (nums[i] == nums[i - 1])) //note
                    continue;
                for (int j = i + 1; j < nums.Count(); j++)
                {
                    int value1 = nums[i];
                    int value2 = nums[j];
                    int remain = -(value1 + value2);
                    if (value2indexlist.ContainsKey(remain))
                    {
                        List<int> temp = value2indexlist[remain];
                        foreach (int index_per in temp)
                        {
                            if ((index_per != i) && (index_per != j) && (index_per > j))
                            {
                                result.Add(new List<int>() { value1, value2, remain });
                            }
                        }
                    }
                }
            }
            return result;

        }

        //15. 3Sum O(n*n) rewrite
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> answer = new List<IList<int>>();
            nums = nums.OrderBy(n => n).ToArray();
            for (int a = 0; a < nums.Length - 2; a++)
            {
                if ((a > 0) && (nums[a] == nums[a - 1]))  //note:
                    continue;
                int b = a + 1;
                int c = nums.Length - 1;
                while (b < c)
                {
                    int sum = nums[a] + nums[b] + nums[c];
                    if (sum == 0)
                    {
                        answer.Add(new List<int> { nums[a], nums[b], nums[c] });
                        b++; //note:
                        while ((b < c) && (nums[b] == nums[b - 1]))  //note:
                            b++;

                    }
                    else if (sum < 0)
                    {
                        b++;
                    }
                    else
                    {
                        c--;
                    }
                }
            }
            return answer;
        }

        //16. 3Sum Closest O(n*n)
        public int ThreeSumClosest(int[] nums, int target)
        {
            nums = nums.OrderBy(n => n).ToArray();
            int min_distance = 999;
            int result = 0;
            for (int a = 0; a < nums.Length - 2; a++)
            {
                int b = a + 1;
                int c = nums.Length - 1;

                while (b < c)
                {
                    int current = nums[a] + nums[b] + nums[c] - target;

                    if (min_distance > Math.Abs(current))
                    {
                        min_distance = Math.Abs(current);
                        result = nums[a] + nums[b] + nums[c];
                    }

                    if (current == 0)
                    {
                        return nums[a] + nums[b] + nums[c];
                    }
                    else if (current > 0)
                    {
                        c--;
                    }
                    else
                    {
                        b++;
                    }
                }
            }
            return result;
        }

        //17. Letter Combinations of a Phone Number note:rewrite not difficult
        static public IList<string> LetterCombinations(string digits)
        {
            if (digits == "")
                return new List<string>(); //note the "" input
            IList<string> result_list = new List<string>() { "" };
            Dictionary<char, List<string>> num2letterlist = new Dictionary<char, List<string>>();
            num2letterlist.Add('2', new List<string>() { "a", "b", "c" });
            num2letterlist.Add('3', new List<string>() { "d", "e", "f" });
            num2letterlist.Add('4', new List<string>() { "g", "h", "i" });
            num2letterlist.Add('5', new List<string>() { "j", "k", "l" });
            num2letterlist.Add('6', new List<string>() { "m", "n", "o" });
            num2letterlist.Add('7', new List<string>() { "p", "q", "r", "s" });
            num2letterlist.Add('8', new List<string>() { "t", "u", "v" });
            num2letterlist.Add('9', new List<string>() { "w", "x", "y", "z" });

            foreach (char item in digits)
            {
                if ((item == '0') || (item == '1'))
                    continue;
                List<string> char_list = num2letterlist[item];
                IList<string> temp_result_list = new List<string>();
                foreach (string old in result_list)
                {
                    foreach (string char_item in char_list)
                    {
                        temp_result_list.Add(old + char_item);
                    }
                }
                result_list = temp_result_list;
            }
            return result_list;
        }

        //18. 4Sum O[n*n] note: we can see another solution in http://www.cnblogs.com/strugglion/p/6412116.html
        static public IList<IList<int>> FourSum(int[] nums, int target)
        {
            nums = nums.OrderBy(n => n).ToArray();
            IList<IList<int>> result = new List<IList<int>>();
            for (int a = 0; a < nums.Length - 3; a++)
            {
                while ((a > 0) && (nums[a - 1] == nums[a]))
                {
                    a++;
                }
                for (int b = a + 1; b < nums.Length - 2; b++)
                {
                    while ((b > a + 1) && (nums[b - 1] == nums[b]) && (b < nums.Length - 2)) //note must add b > a + 1 && b < nums.Length - 2
                    {
                        b++;
                    }
                    int c = b + 1;
                    int d = nums.Length - 1;
                    while (c < d)
                    {
                        int current = nums[a] + nums[b] + nums[c] + nums[d] - target;
                        if (current == 0)
                        {
                            result.Add(new List<int>() { nums[a], nums[b], nums[c], nums[d] });
                            c++; //note must c++
                            while ((c > b + 1) && (nums[c - 1] == nums[c]) && (c < nums.Length - 1)) //note must add c> b + 1 && c < nums.Length - 1
                            {

                                c++;
                            }
                        }
                        else if (current > 0)
                        {
                            d--;
                        }
                        else
                        {
                            c++;
                        }
                    }
                }
            }
            return result;

        }

        //19. Remove Nth Node From End of List note:
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode first_node = head;
            ListNode second_node = head;
            ListNode second_pre_node = new ListNode(0);
            second_pre_node.next = second_node; //note: must add
            ListNode helper = second_pre_node;//note: must let second_pre_node asign helper
            int index = 1;
            while (first_node != null)
            {
                if (index > n)
                {
                    second_pre_node = second_node;
                    second_node = second_node.next;
                }
                first_node = first_node.next;
                index++;
            }

            second_pre_node.next = second_node.next;
            return helper.next; //note: must return helper.next
        }

        //22. Generate Parentheses note:
        static public IList<string> GenerateParenthesis(int n)
        {
            IList<string> result = new List<string>() { "(" };
            for (int i = 0; i < 2*n-1; i++) //note: must loop to 2*n-1 not 2*n
            {
                IList<string> result_temp = new List<string>();
                foreach (string item in result)
                {
                    bool flag = Judge_Full(item);
                    if (flag)//full
                    {
                        result_temp.Add(item + "(");
                    }
                    else
                    {
                        string[] st = item.Split(new char[] { '(' });

                        if (st.Count() < n + 1)
                        {
                            result_temp.Add(item + "(");
                        }                        
                        result_temp.Add(item + ")");
                       
                    }
                }
                result=result_temp;
            }
            return result;
        }

        static public bool Judge_Full(string input)
        {
            Stack<char> result = new Stack<char>();
            foreach (char letter in input)
            {
                if (letter == '(')
                    result.Push(letter);
                else
                    result.Pop();
            }
            if (result.Count() == 0)
                return true;//full
            else
                return false;//not_full
        }

        //24. Swap Nodes in Pairs
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null)
                return null;
            ListNode first = head.next;
            ListNode second = head;
            ListNode helper = new ListNode(0);
            helper.next = second;
            ListNode pro = helper;

            while (first != null)
            {
                second.next = first.next;
                first.next = second;
                pro.next = first;

                if (second.next == null)
                    break;
                second = second.next;
                pro = pro.next.next;
                first = first.next.next.next;
            }
            return helper.next;
        }

        //29. Divide Two Integers note:rewrite
        public int Divide(int dividend, int divisor)
        {
            bool neg = false;
            if (((dividend > 0) && (divisor < 0)) || ((dividend < 0) && (divisor > 0)))
                neg = true;

            long a = Math.Abs((long)dividend); // note must convert(long)
            long b = Math.Abs((long)divisor); // note must convert(long)
            int shift = 0;
            while (b << shift <= a) // note must contain =
            {
                shift++;
            }

            shift = shift - 1;

            long answer = 0;
            while (shift >= 0)
            {
                if (b << shift <= a)
                {
                    answer += 1L << shift;
                    a -= b << shift;
                }
                shift--;
            }

            answer = neg ? -answer : answer;

            if (answer < int.MinValue)
            {
                return int.MinValue;
            }

            if (answer > int.MaxValue)
            {
                return int.MaxValue;
            }
            return (int)answer;
        }

        //31. Next Permutation note: must rewrite
        public void NextPermutation(int[] num)
        {
            int start = 0;
            int end = num.Length - 1;
            for (int y = num.Length - 1; y >= 1; y--)
            {
                if (num[y] > num[y - 1])
                {
                    start = y;
                    for (int x = num.Length - 1; x >= y; x--)
                    {
                        if (num[x] > num[y - 1])
                        {
                            int temp = num[x];
                            num[x] = num[y - 1];
                            num[y - 1] = temp;
                            break;
                        }
                    }
                    break;
                }
            }

            while (start < end)
            {
                int temp = num[start];
                num[start] = num[end];
                num[end] = temp;
                start++;
                end--;
            }
        }


        //33. Search in Rotated Sorted Array note: must rewrite binary classification
        public int Search(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Count() - 1;
            int m = 0;
            while (l <= r) //note equation
            {
                m = (l + r) / 2;
                if (nums[m] == target)
                    return m;
                if (nums[m] >= nums[l]) //note equation
                {
                    if ((nums[l] <= target) && (nums[m] >= target)) //note equation
                    {
                        r = m - 1;
                    }
                    else
                        l = m + 1;
                }
                else
                {
                    if ((nums[r] >= target) && (nums[m] <= target)) //note equation
                    {
                        l = m + 1;
                    }
                    else
                    {
                        r = m - 1;
                    }
                }
            }
            return -1;
        }

        //34. Search for a Range note: must rewrite binary classification
        public int[] SearchRange(int[] nums, int target)
        {
            int[] res = new int[] { -1, -1 };
            if ((nums == null) || (nums.Count() == 0))
                return res;
            int ll = 0;
            int lr = nums.Length - 1;
            while (ll <= lr)
            {
                int m = (ll + lr) / 2;
                if (nums[m] < target)
                {
                    ll = m + 1;
                }
                else
                    lr = m - 1;
            }

            int rl = 0;
            int rr = nums.Length - 1;
            while (rl <= rr)
            {
                int m = (rl + rr) / 2;
                if (nums[m] <= target)
                {
                    rl = m + 1;
                }
                else
                    rr = m - 1;
            }

            if (ll <= rr)
            {
                res[0] = ll;
                res[1] = rr;
            }
            return res;
        }

        // 39. Combination Sum note:rewrite  take time to think the recursive algorithm.  depth first problem
        static public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            
            candidates = candidates.OrderBy(n => n).ToArray();

            return helper( new Stack<int>(), candidates, target, 0);
        }
        static public IList<IList<int>> helper(Stack<int> result, int[] candidates, int target, int index)
        {
            IList<IList<int>> results = new List<IList<int>>();

            for (int i = index; i < candidates.Count(); i++)
            {
                //Console.WriteLine("i: "+i+"--target: "+target+"--index: "+index+ "--R:"+string.Join(",",result));
                int t = target - candidates[i];

                if (t < 0)
                {
                    break;
                }
                else if (t == 0)
                {
                    result.Push(candidates[i]);
                    results.Add(result.ToList());
                    result.Pop();
                    break;
                }
                else
                {
                    result.Push(candidates[i]);
                    IList<IList<int>> results_temp=helper(result, candidates, t, i);
                    result.Pop();
                    foreach (List<int> item in results_temp)
                        results.Add(item);
                }
            }

            //result.Pop();

            return results;
        }

        //40. Combination Sum II  recursive algorithm
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            candidates = candidates.OrderBy(n => n).ToArray();
            return helper_II(candidates, new Stack<int>(), 0, target);
        }
        public IList<IList<int>> helper_II(int[] candidates, Stack<int> result, int index, int target)
        {
            IList<IList<int>> results = new List<IList<int>>();
            for (int i = index; i < candidates.Count(); i++)
            {
                if ((i != index) && (i > 0) && (candidates[i] == candidates[i - 1])) //note: please note these three conditions, especially the first one condition.
                {
                    continue;
                }
                int t = target - candidates[i];
                if (t < 0)
                {
                    break;
                }
                else if (t == 0)
                {
                    result.Push(candidates[i]);
                    results.Add(result.ToList());
                    result.Pop();
                    break;
                }
                else
                {
                    result.Push(candidates[i]);
                    IList<IList<int>> results_temp = helper_II(candidates, result, i + 1, t);
                    result.Pop();
                    foreach (List<int> term in results_temp)
                        results.Add(term);

                }
            }
            return results;
        }

        //43. Multiply Strings note: re-read this problem
        static public string Multiply(string num1, string num2)
        {
            int[] answers = new int[num1.Length + num2.Length];
            for (int i = num2.Count() - 1; i >= 0; i--)
            {

                int flag = 0;
                for (int j = num1.Count() - 1; j >= 0; j--)
                {
                    int temp3 = (num2[i] - 48) * (num1[j] - 48) + answers[i + j + 1] + flag;
                    flag = temp3 / 10;
                    answers[i + j + 1] = temp3 % 10;
                }
                if (flag != 0)
                {
                    answers[i] = flag;
                }

            }
            string res = string.Join("", answers).TrimStart('0');
            if (res == "")
                return "0";
            else
                return res;
        }


        //46. Permutations note: re-read this problem recursive algorithm
        static public IList<IList<int>> Permute(int[] nums)
        {
            return helper_permutations(0, new Stack<int>(), new Stack<int>(), nums);
        }
        static public IList<IList<int>> helper_permutations(int index, Stack<int> result, Stack<int> index_dict, int[] nums)
        {
            IList<IList<int>> results = new List<IList<int>>();
            for (int i = index; i < nums.Count(); i++)
            {
                if (index_dict.Contains(i))
                    continue;
                result.Push(nums[i]);
                bool flag = false;
                if (!index_dict.Contains(i))
                {
                    flag = true;
                    index_dict.Push(i);
                }

                if (result.Count() == nums.Count())
                {
                    results.Add(result.ToList()); // note: tolist not toarray!!!!
                }
                else
                {
                    IList<IList<int>> results_temp = helper_permutations(0, result, index_dict, nums);
                    foreach (var term in results_temp)
                    {
                        results.Add(term);
                    }
                        
                }
                if (flag)
                    index_dict.Pop();
                result.Pop();
            }
            return results;
        }

        //47. Permutations II
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            nums = nums.OrderBy(n => n).ToArray();
            return helper_permutationsunique(0, new Stack<int>(), new Stack<int>(), nums);
        }
        static public IList<IList<int>> helper_permutationsunique(int index, Stack<int> result, Stack<int> index_dict, int[] nums)
        {
            IList<IList<int>> results = new List<IList<int>>();
            bool first_flag = true;
            List<int> temp = new List<int>(); // note: this is very important
            for (int i = index; i < nums.Count(); i++)
            {
                if (index_dict.Contains(i))
                    continue;

                if ((first_flag == false) && (i > 0) && (nums[i] == nums[i - 1]) && (temp.Contains(nums[i]))) //note: these three conditions
                {
                    continue;
                }

                first_flag = false;
                result.Push(nums[i]);
                bool flag = false;
                if (!index_dict.Contains(i))
                {
                    flag = true;
                    index_dict.Push(i);
                }

                if (result.Count() == nums.Count())
                {
                    results.Add(result.ToList()); // note: tolist not toarray!!!!
                }
                else
                {
                    IList<IList<int>> results_temp = helper_permutationsunique(0, result, index_dict, nums);
                    foreach (var term in results_temp)
                    {
                        results.Add(term);
                    }


                }
                if (flag)
                    index_dict.Pop();
                int temp_term = result.Pop();
                temp.Add(temp_term);
            }
            return results;
        }

        //48. Rotate Image  try other solutions if have time
        public void Rotate(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }

            for (int i = 0; i < n; i++)
            {
                int l = 0;
                int r = n - 1;
                while (l < r)
                {
                    int temp = matrix[i, l];
                    matrix[i, l] = matrix[i, r];
                    matrix[i, r] = temp;
                    l++;
                    r--;
                }
            }
        }

        //49. Group Anagrams
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> flag2strlist = new Dictionary<string, List<string>>();
            foreach (string str in strs)
            {
                char[] st = str.ToArray();
                Array.Sort(st);
                string str_temp = string.Join("", st);
                if (!flag2strlist.ContainsKey(str_temp))
                {
                    List<string> temp_list = new List<string>();
                    temp_list.Add(str);
                    flag2strlist.Add(str_temp, temp_list);
                }
                else
                {
                    List<string> temp_list = flag2strlist[str_temp];
                    temp_list.Add(str);
                    flag2strlist[str_temp] = temp_list;
                }
            }
            IList<IList<string>> results = new List<IList<string>>();
            foreach (List<string> temp in flag2strlist.Values)
            {
                results.Add(temp);
            }
            return results;
        }


        //50. Pow(x, n)  note: re-read 1.n may be negative 2.Math.Abs() may overflow
        public double MyPow(double x, int n)
        {
            if (n == 0)
                return 1;
            bool neg = n < 0 ? true : false; //note
            long n_temp = (long)n;
            if (neg)
                n_temp = Math.Abs(n_temp); //note
            double temp = 1;
            if (n_temp >= 1)
            {
                long m = n_temp / 2;
                temp = MyPow(x, (int)m); 
                temp = temp * temp; //note: the first is wrong --MyPow(x, (int)m)*MyPow(x, (int)m);
                if ((2 * m) != n_temp)
                    temp = temp * x;
            }
            if (neg == true)
                return 1 / temp;
            else
                return temp;
        }


        //54. Spiral Matrix note: re-read this problem
        public IList<int> SpiralOrder(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            int count = Math.Min(row, column) / 2;
            IList<int> results = new List<int>();
            for (int c = 0; c < count; c++)
            {
                for (int i = c; i < column - c-1; i++)
                {
                    results.Add(matrix[c,i]);
                }

                for (int j= c;j<row-c-1;j++)
                {
                    results.Add(matrix[j, column-c-1]);
                }

                for (int i=column-c-1;i>=c+1;i--)
                {
                    results.Add(matrix[row-c-1,i]);
                }

                for (int j = row - c - 1; j >= c + 1; j--)
                {
                    results.Add(matrix[j,c]);
                }
                
            }

            if (Math.Min(row, column) % 2 != 0)
            {
                if (row == column)
                {
                    results.Add(matrix[count,count]);
                }
                if (row < column)
                {
                    for (int i = count; i < column - count; i++)
                    {
                        results.Add(matrix[count,i]);
                    }
                }
                if (column < row)
                {
                    for (int j = count; j < row - count; j++)
                    {
                        results.Add(matrix[j,count]);
                    }
                }
            }

            return results;
        }


    }

    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
    }
}
