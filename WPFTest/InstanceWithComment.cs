using Autodesk.Revit.DB;
using System.Windows;
using System;
using WPFTest.Utils;

namespace WPFTest
{
    public class InstanceWithComment : MVVM.ViewModelBase
    {
        public string Category { get; }
        public ElementId Id { get; }
        public string Name { get; }
        public bool Edited { get; private set; }

        string _comment;
        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                CommentType = value.GetCommentType();
                OnPropertyChanged(nameof(Comment));
                OnPropertyChanged(nameof(CommentType));
                Edited = true;
            }
        }
        public TypeOfComment CommentType { get; set; }

        public InstanceWithComment(FamilyInstance Instance)
        {
            if (Instance == null)
                throw new ArgumentNullException(nameof(Instance));

            Id = Instance.Id;
            Name = Instance.Name;
            Category = Instance.Category.Name;
            Comment = Instance.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).AsString();
            Edited = false;
        }

    }
    //class InstanceWithComment : DependencyObject
    //{
    //    public static readonly DependencyProperty CommentProperty;
    //    public static readonly DependencyProperty CommentTypeProperty;

    //    static InstanceWithComment()
    //    {
    //        CommentProperty = DependencyProperty.Register("Comment", typeof(string), typeof(InstanceWithComment));
    //        CommentTypeProperty = DependencyProperty.Register("CommentType", typeof(TypeOfComment), typeof(InstanceWithComment));
    //    }

    //    public string Category { get; }
    //    public ElementId Id { get; }
    //    public string Name { get; }
    //    public bool Edited { get; private set; }

    //    public string Comment
    //    {
    //        get { return (string)GetValue(CommentProperty); }
    //        set
    //        {
    //            SetValue(CommentProperty, value);
    //            // CommentType = value.GetCommentType();
    //            SetValue(CommentTypeProperty, value.GetCommentType());
    //            Edited = true;
    //        }
    //    }
    //    public TypeOfComment CommentType
    //    {
    //        get { return (TypeOfComment)GetValue(CommentTypeProperty); }
    //        private set { SetValue(CommentTypeProperty, value); }
    //    }

    //    public InstanceWithComment(FamilyInstance Instance)
    //    {
    //        if (Instance == null)
    //            throw new ArgumentNullException(nameof(Instance));

    //        Id = Instance.Id;
    //        Name = Instance.Name;
    //        Category = Instance.Category.Name;
    //        Comment = Instance.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).AsString();
    //        Edited = false;
    //    }

    //}


}
