//-----------------------------------------------------------------------------
// FILE:	    PostmatesErrorCodes.cs
// CONTRIBUTOR: Ian White
// COPYRIGHT:	Copyright (c) 2018-2020 by Loopie, Inc.  All rights reserved.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Postmates.Model
{
    /// <summary>
    /// Enumerates Postmates error codes.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PostmatesErrorCodes
    {
        /// <summary>
        /// Forbidden from Postmates.
        /// </summary>
        [EnumMember(Value = "forbidden")]
        Forbidden,

        /// <summary>
        /// Unknown error from Postmates.
        /// </summary>
        [EnumMember(Value = "unknown_error")]
        UnknownError,

        /// <summary>
        /// An active delivery like this already exists.
        /// </summary>
        [EnumMember(Value = "duplicate_delivery")]
        DuplicateDelivery,

        /// <summary>
        /// The parameters of your request were invalid.
        /// </summary>
        [EnumMember(Value = "invalid_params")]
        InvalidParams,

        /// <summary>
        /// The specified location was not understood.
        /// </summary>
        [EnumMember(Value = "unknown_location")]
        UnknownLocation,

        /// <summary>
        /// The requested API version is not valid
        /// </summary>
        [EnumMember(Value = "invalid_api_version")]
        InvalidApiVersion,

        /// <summary>
        /// The specified location is not in a deliverable area.
        /// </summary>
        [EnumMember(Value = "address_undeliverable")]
        AddressUndeliverable,

        /// <summary>
        /// The price quote specified has expired.
        /// </summary>
        [EnumMember(Value = "expired_quote")]
        ExpiredQuote,

        /// <summary>
        /// The price quote specified has been used.
        /// </summary>
        [EnumMember(Value = "used_quote")]
        UsedQuote,

        /// <summary>
        /// The price quote specified doesn't match the delivery.
        /// </summary>
        [EnumMember(Value = "mismatched_price_quote")]
        MismatchedPriceQuote,

        /// <summary>
        /// Your account's payment information has not be provided.
        /// </summary>
        [EnumMember(Value = "missing_payment")]
        MissingPayment,

        /// <summary>
        /// Tipping limit exceeded
        /// </summary>
        [EnumMember(Value = "max_tip_exceeded")]
        MaxTipExceeded,

        /// <summary>
        /// Delivery does not accept tip.
        /// </summary>
        [EnumMember(Value = "no_tip")]
        NoTip,

        /// <summary>
        /// Tip was already recorded
        /// </summary>
        [EnumMember(Value = "tip_already_recorded_error")]
        TipAlreadyRecordedError,

        /// <summary>
        /// Delivery cannot tip at this time.
        /// <summary>
        [EnumMember(Value = "invalid_tipping_state")]
        InvalidTippingState,

        /// <summary>
        /// You cannot cancel this delivery. Contact customer service.
        /// <summary>
        [EnumMember(Value = "noncancelable_delivery")]
        NoncancelableDelivery,

        /// <summary>
        /// Pickup ready time must be specified when passing in pickup/dropoff windows.
        /// <summary>
        [EnumMember(Value = "pickup_ready_time_not_specified")]
        PickupReadyTimeNotSpecified,

        /// <summary>
        /// The pickup window needs to be at least 10 minutes long.
        /// <summary>
        [EnumMember(Value = "pickup_window_too_small")]
        PickupWindowTooSmall,

        /// <summary>
        /// The dropoff deadline needs to be at least 20 minutes after the dropoff ready time.
        /// <summary>
        [EnumMember(Value = "dropoff_deadline_too_early")]
        DropoffDeadlineTooEarly,

        /// <summary>
        /// The dropoff deadline needs to be after the pickup deadline.
        /// <summary>
        [EnumMember(Value = "dropoff_deadline_before_pickup_deadline")]
        DropoffDeadlineBeforePickupDeadline,

        /// <summary>
        /// The dropoff ready time needs to be at or before the pickup deadline.
        /// <summary>
        [EnumMember(Value = "dropoff_ready_after_pickup_deadline")]
        DropoffReadyAfterPickupDeadline,

        /// <summary>
        /// The pickup ready time cannot be in the past
        /// <summary>
        [EnumMember(Value = "pickup_ready_too_early")]
        PickupReadyTooEarly,

        /// <summary>
        /// The pickup deadline time needs to be at least 20 minutes from now.
        /// <summary>
        [EnumMember(Value = "pickup_deadline_too_early")]
        PickupDeadlineTooEarly,

        /// <summary>
        /// The pickup ready time needs to be at within the next 30 days.
        /// <summary>
        [EnumMember(Value = "pickup_ready_too_late")]
        PickupReadyTooLate,

        /// <summary>
        /// The card details were invalid.
        /// <summary>
        [EnumMember(Value = "card_invalid")]
        CardInvalid,

        /// <summary>
        /// The given card already exists.
        /// <summary>
        [EnumMember(Value = "card_duplicate")]
        CardDuplicate,

        /// <summary>
        /// The given card has expired.
        /// <summary>
        [EnumMember(Value = "card_expired")]
        CardExpired,

        /// <summary>
        /// The card was declined.
        /// <summary>
        [EnumMember(Value = "card_declined")]
        CardDeclined,

        /// <summary>
        /// Your account is passed due. Payment is required.
        /// <summary>
        [EnumMember(Value = "customer_suspended")]
        CustomerSuspended,

        /// <summary>
        /// Your account is not allowed to create deliveries.
        /// <summary>
        [EnumMember(Value = "customer_blocked")]
        CustomerBlocked,

        /// <summary>
        /// Your account is forbidden from accessing that catalog
        /// <summary>
        [EnumMember(Value = "catalog_access_forbidden")]
        CatalogAccessForbidden,

        /// <summary>
        /// Customer does not exist
        /// <summary>
        [EnumMember(Value = "customer_not_found")]
        CustomerNotFound,

        /// <summary>
        /// The requested delivery does not exist.
        /// <summary>
        [EnumMember(Value = "delivery_not_found")]
        DeliveryNotFound,

        /// <summary>
        /// Account does not exist.
        /// <summary>
        [EnumMember(Value = "account_not_found")]
        AccountNotFound,

        /// <summary>
        /// Quote does not exist.
        /// <summary>
        [EnumMember(Value = "quote_not_found")]
        QuoteNotFound,

        /// <summary>
        /// Developer does not exist.
        /// <summary>
        [EnumMember(Value = "developer_not_found")]
        DeveloperNotFound,

        /// <summary>
        /// Webhook does not exist.
        /// <summary>
        [EnumMember(Value = "webhook_not_found")]
        WebhookNotFound,

        /// <summary>
        /// Fence does not exist
        /// <summary>
        [EnumMember(Value = "fence_not_found")]
        FenceNotFound,

        /// <summary>
        /// The requested catalog update job was not found
        /// <summary>
        [EnumMember(Value = "catalog_update_job_not_found")]
        CatalogUpdateJobNotFound,

        /// <summary>
        /// The request timed out.
        /// <summary>
        [EnumMember(Value = "request_timeout")]
        RequestTimeout,

        /// <summary>
        /// Your account's limits have been exceeded.
        /// <summary>
        [EnumMember(Value = "customer_limited")]
        CustomerLimited,

        /// <summary>
        /// All of our couriers are currently busy
        /// <summary>
        [EnumMember(Value = "couriers_busy")]
        CouriersBusy,

        /// <summary>
        /// All of our robo couriers are currently busy
        /// <summary>
        [EnumMember(Value = "robo_couriers_busy")]
        RoboCouriersBusy,

        /// <summary>
        /// Service is currently unavailable. Please try again later.
        /// <summary>
        [EnumMember(Value = "service_unavailable")]
        ServiceUnavailable
    }
}