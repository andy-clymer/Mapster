﻿using System;
using System.Collections.Generic;
using Fpr.Models;

namespace Fpr
{

    internal class TypeAdapterConfigSettings
    {
        public TypeAdapterConfigSettings()
        {
            NewInstanceForSameType = true;
        }

        /// <summary>
        /// This property only use TypeAdapter.Adapt() method. Project().To() not use this property. Default: true
        /// </summary>
        internal bool NewInstanceForSameType { get; set; }

        internal IDictionary<Type, Func<object, object>> CombinedTransforms
        {
            get { return TypeAdapterConfig.GlobalSettings.DestinationTransforms.Transforms; }
        }
    }

    internal class TypeAdapterConfigSettings<TSource>
    {
        public readonly List<string> IgnoreMembers = new List<string>();
        public readonly List<InvokerModel<TSource>> Resolvers = new List<InvokerModel<TSource>>();
        public readonly TransformsCollection DestinationTransforms = new TransformsCollection();

        public TypeAdapterConfigSettings()
        {
            foreach (var transform in TypeAdapterConfig.GlobalSettings.DestinationTransforms.Transforms)
            {
                DestinationTransforms.Transforms.Add(transform.Key, transform.Value);
            }
        }

        public void Reset()
        {
            IgnoreMembers.Clear();
            Resolvers.Clear();
            DestinationTransforms.Clear();
        }

        public int MaxDepth { get; set; }

        /// <summary>
        /// This property only use TypeAdapter.Adapt() method. Project().To() not use this property. Default: true
        /// </summary>
        public bool? NewInstanceForSameType { get; set; }

        /// <summary>
        /// This property only use TypeAdapter.Adapt() method. Project().To() not use this property. Default: false
        /// </summary>
        public bool? IgnoreNullValues { get; set; }

        /// <summary>
        /// Determine whether or not to convert a null or empty string to the default enumeration value
        /// </summary>
        public bool? DefaultEnumsOnNullOrEmptyString { get; set; }


    }
}