﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Microsoft.CoreWf.Expressions
{
    //[Serializable]
    public class LambdaSerializationException : Exception
    {
        public LambdaSerializationException()
            : base(SR.LambdaNotXamlSerializable)
        {
        }

        public LambdaSerializationException(string message)
            : base(message)
        {
        }

        public LambdaSerializationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        //protected LambdaSerializationException(SerializationInfo info, StreamingContext context)
        //    : base(info, context)
        //{            
        //}
    }
}