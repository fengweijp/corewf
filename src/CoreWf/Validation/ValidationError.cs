// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CoreWf.Runtime;
using System.Globalization;

namespace CoreWf.Validation
{
    [Fx.Tag.XamlVisible(false)]
    public class ValidationError
    {
        private Activity _source;

        public ValidationError(string message)
            : this(message, false, string.Empty)
        {
        }

        public ValidationError(string message, bool isWarning)
            : this(message, isWarning, string.Empty)
        {
        }

        public ValidationError(string message, bool isWarning, string propertyName)
            : this(message, isWarning, propertyName, null)
        {
        }

        public ValidationError(string message, bool isWarning, string propertyName, object sourceDetail)
            : this(message, isWarning, propertyName, null)
        {
            this.SourceDetail = sourceDetail;
        }

        internal ValidationError(string message, Activity activity)
            : this(message, false, string.Empty, activity)
        {
        }

        internal ValidationError(string message, bool isWarning, Activity activity)
            : this(message, isWarning, string.Empty, activity)
        {
        }

        internal ValidationError(string message, bool isWarning, string propertyName, Activity activity)
        {
            this.Message = message;
            this.IsWarning = isWarning;
            this.PropertyName = propertyName;

            if (activity != null)
            {
                this.Source = activity;
                this.Id = activity.Id;
                this.SourceDetail = activity.Origin;
            }
        }

        public string Message
        {
            get;
            internal set;
        }

        public bool IsWarning
        {
            get;
            private set;
        }

        public string PropertyName
        {
            get;
            private set;
        }

        public string Id
        {
            get;
            internal set;
        }

        public Activity Source
        {
            get
            {
                return _source;
            }
            internal set
            {
                _source = value;
                if (_source != null && this.SourceDetail == null)
                {
                    this.SourceDetail = _source.Origin;
                }
            }
        }

        public object SourceDetail
        {
            get;
            internal set;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture,
                "ValidationError {{ Message = {0}, Source = {1}, PropertyName = {2}, IsWarning = {3} }}",
                this.Message,
                this.Source,
                this.PropertyName,
                this.IsWarning);
        }
    }
}
