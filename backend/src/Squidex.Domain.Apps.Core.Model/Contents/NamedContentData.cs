﻿// ==========================================================================
//  Squidex Headless CMS
// ==========================================================================
//  Copyright (c) Squidex UG (haftungsbeschränkt)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using System.Diagnostics.CodeAnalysis;
using Squidex.Infrastructure;

namespace Squidex.Domain.Apps.Core.Contents
{
    public sealed class NamedContentData : ContentData<string>, IEquatable<NamedContentData>
    {
        public NamedContentData()
            : base(StringComparer.Ordinal)
        {
        }

        public NamedContentData(NamedContentData source)
            : base(source, StringComparer.Ordinal)
        {
        }

        public NamedContentData(int capacity)
            : base(capacity, StringComparer.Ordinal)
        {
        }

        public static NamedContentData Merge(params NamedContentData[] contents)
        {
            return MergeTo(new NamedContentData(), contents);
        }

        public NamedContentData MergeInto(NamedContentData target)
        {
            return Merge(target, this);
        }

        public NamedContentData ToCleaned()
        {
            return Clean(this, new NamedContentData());
        }

        public NamedContentData AddField(string name, ContentFieldData? data)
        {
            Guard.NotNullOrEmpty(name, nameof(name));

            this[name] = data;

            return this;
        }

        public NamedContentData Clone()
        {
            var clone = new NamedContentData(Count);

            foreach (var (key, value) in this)
            {
                clone[key] = value?.Clone()!;
            }

            return clone;
        }

        public bool Equals([AllowNull] NamedContentData other)
        {
            return base.Equals(other);
        }
    }
}
