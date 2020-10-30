﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYWPF.Sample.Effect
{
    public class ExpanderClass
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 标题图片
        /// </summary>
        public string ImgUrl { get; set; }

        public ExpanderClass()
        {
            Title = string.Empty;
            ImgUrl = string.Empty;
        }

        public ExpanderClass(string t, string url)
        {
            Title = t;
            ImgUrl = url;
        }
    }
}
