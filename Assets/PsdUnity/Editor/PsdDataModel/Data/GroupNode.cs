﻿using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PSDUnity
{
    public abstract class GroupNode
    {
        public string name;
        public ControlType controltype;
        public List<string> arguments = new List<string>();
        public Rect rect;
        public abstract List<ImgNode> images { get; set; }
        public abstract List<GroupNode> groups { get; set; }
        public abstract GroupNode InsertChild(string name, Rect rect);
        public void GetImgNodes(List<ImgNode> imgNodes)
        {
            if(images != null)
            {
                imgNodes.AddRange(images);
            }
            if (groups != null)
            {
                foreach (var item in groups)
                {
                    item.GetImgNodes(imgNodes);
                }
            }
        }

        public GroupNode(string name,Rect rect)
        {
            //利用名字解析controlType和arguments
            this.name = name;
            this.rect = rect;
        }
    }
    [System.Serializable]
    public class GroupNode1 : GroupNode
    {
        public List<GroupNode2> _groups = new List<GroupNode2>();
        public List<ImgNode> _images = new List<ImgNode>();

        public GroupNode1(string name, Rect rect) : base(name, rect)
        {
        }

        public override List<ImgNode> images
        {
            get
            {
                return _images;
            }

            set
            {
                _images = value;
            }
        }
        public override List<GroupNode> groups
        {
            get
            {
                if (_groups == null) _groups = new List<GroupNode2>();
                return _groups.ConvertAll<GroupNode>(x => x);
            }

            set
            {
                _groups = value.ConvertAll<GroupNode2>(x => (GroupNode2)x);
            }
        }

        public override GroupNode InsertChild(string name, Rect rect)
        {
            GroupNode2 node = new PSDUnity.GroupNode2(name,rect);
            _groups.Add(node);
            return node;
        }
    }
    [System.Serializable]
    public class GroupNode2 : GroupNode
    {
        public List<GroupNode3> _groups = new List<GroupNode3>();
        public List<ImgNode> _images = new List<ImgNode>();

        public GroupNode2(string name, Rect rect) : base(name, rect)
        {
        }

        public override List<ImgNode> images
        {
            get
            {
                return _images;
            }

            set
            {
                _images = value;
            }
        }
        public override List<GroupNode> groups
        {
            get
            {
                if (_groups == null) _groups = new List<GroupNode3>();
                return _groups.ConvertAll<GroupNode>(x => x);
            }

            set
            {
                _groups = value.ConvertAll<GroupNode3>(x => (GroupNode3)x);
            }
        }
        public override GroupNode InsertChild(string name, Rect rect)
        {
            GroupNode3 node = new PSDUnity.GroupNode3(name, rect);
            _groups.Add(node);
            return node;
        }
    }
    [System.Serializable]
    public class GroupNode3 : GroupNode
    {
        public List<GroupNode4> _groups = new List<GroupNode4>();
        public List<ImgNode> _images = new List<ImgNode>();

        public GroupNode3(string name, Rect rect) : base(name, rect)
        {
        }

        public override List<ImgNode> images
        {
            get
            {
                return _images;
            }

            set
            {
                _images = value;
            }
        }
        public override List<GroupNode> groups
        {
            get
            {
                if (_groups == null) _groups = new List<GroupNode4>();
                return _groups.ConvertAll<GroupNode>(x => x);
            }

            set
            {
                _groups = value.ConvertAll<GroupNode4>(x => (GroupNode4)x);
            }
        }
        public override GroupNode InsertChild(string name, Rect rect)
        {
            GroupNode4 node = new PSDUnity.GroupNode4(name, rect);
            _groups.Add(node);
            return node;
        }
    }
    [System.Serializable]
    public class GroupNode4 : GroupNode
    {
        public List<GroupNode5> _groups;
        public List<ImgNode> _images = new List<ImgNode>();

        public GroupNode4(string name, Rect rect) : base(name, rect)
        {
        }

        public override List<ImgNode> images
        {
            get
            {
                return _images;
            }

            set
            {
                _images = value;
            }
        }
        public override List<GroupNode> groups
        {
            get
            {
                if (_groups == null) _groups = new List<GroupNode5>();
                return _groups.ConvertAll<GroupNode>(x => x);
            }

            set
            {
                _groups = value.ConvertAll<GroupNode5>(x => (GroupNode5)x);
            }
        }
        public override GroupNode InsertChild(string name, Rect rect)
        {
            GroupNode5 node = new PSDUnity.GroupNode5(name, rect);
            _groups.Add(node);
            return node;
        }
    }
    [System.Serializable]
    public class GroupNode5 : GroupNode
    {
        public List<GroupNode6> _groups;
        public List<ImgNode> _images = new List<ImgNode>();

        public GroupNode5(string name, Rect rect) : base(name, rect)
        {
        }

        public override List<ImgNode> images
        {
            get
            {
                return _images;
            }

            set
            {
                _images = value;
            }
        }
        public override List<GroupNode> groups
        {
            get
            {
                if (_groups == null) _groups = new List<GroupNode6>();
                return _groups.ConvertAll<GroupNode>(x => x);
            }

            set
            {
                _groups = value.ConvertAll<GroupNode6>(x => (GroupNode6)x);
            }
        }
        public override GroupNode InsertChild(string name, Rect rect)
        {
            GroupNode6 node = new PSDUnity.GroupNode6(name, rect);
            _groups.Add(node);
            return node;
        }
    }
    [System.Serializable]
    public class GroupNode6 : GroupNode
    {
        public List<GroupNode7> _groups;
        public List<ImgNode> _images = new List<ImgNode>();

        public GroupNode6(string name, Rect rect) : base(name, rect)
        {
        }

        public override List<ImgNode> images
        {
            get
            {
                return _images;
            }

            set
            {
                _images = value;
            }
        }
        public override List<GroupNode> groups
        {
            get
            {
                if (_groups == null) _groups = new List<GroupNode7>();
                return _groups.ConvertAll<GroupNode>(x => x);
            }

            set
            {
                _groups = value.ConvertAll<GroupNode7>(x => (GroupNode7)x);
            }
        }
        public override GroupNode InsertChild(string name, Rect rect)
        {
            GroupNode7 node = new PSDUnity.GroupNode7(name, rect);
            _groups.Add(node);
            return node;
        }
    }
    [System.Serializable]
    public class GroupNode7 : GroupNode
    {
        public GroupNode7(string name, Rect rect) : base(name, rect)
        {
        }

        public override List<ImgNode> images { get { return null; } set { } }
        public override List<GroupNode> groups { get; set; }
        public override GroupNode InsertChild(string name, Rect rect)
        {
            Debug.Log("cant Insert");
            return null;
        }
    }
}
