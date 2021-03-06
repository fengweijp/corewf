﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using CoreWf;
using CoreWf.Statements;

namespace Test.Common.TestObjects.CustomActivities
{
    public class CustomCompensationScope : Activity
    {
        private Variable<CompensationToken> _handle = new Variable<CompensationToken>() { Name = "handle" };
        private Variable<Exception> _exception = new Variable<Exception>() { Name = "exception" };

        public CustomCompensationScope()
        {
            base.Implementation = () => this.InternalActivities;
        }

        public Activity CSBody
        {
            get;
            set;
        }

        protected override void CacheMetadata(ActivityMetadata metadata)
        {
            // None
        }

        private Sequence InternalActivities
        {
            get
            {
                return new Sequence
                {
                    DisplayName = "CustomCS_Sequence",
                    Variables = { _handle },
                    Activities =
                    {
                        new TryCatch
                        {
                            DisplayName = "CustomCS_TryCatch",
                            Try = new CompensableActivity
                            {
                                DisplayName = "CustomCS_CA",
                                Result = _handle,
                                Body = this.CSBody
                            },
                            Finally = new If((env) => _handle.Get(env) != null)
                            {
                                DisplayName = "CustomCS_If",
                                Then = new Confirm
                                {
                                    DisplayName = "CustomCS_Confirm",
                                    Target = _handle
                                }
                            }
                        }
                    }
                };
            }
        }
    }
}
