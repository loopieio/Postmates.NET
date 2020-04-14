//-----------------------------------------------------------------------------
// FILE:	    PostmatesExceptions.cs
// CONTRIBUTOR: Ian White
// COPYRIGHT:	Copyright (c) 2018-2020 by Loopie, Inc.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

using Postmates.Model;

namespace Postmates.Model
{
    public class ForbiddenException : PostmatesExceptionBase
    {
        public ForbiddenException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }
    public class UnknownErrorException : PostmatesExceptionBase
    {
        public UnknownErrorException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class DuplicateDeliveryException : PostmatesExceptionBase
    {
        public DuplicateDeliveryException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class InvalidParamsException : PostmatesExceptionBase
    {
        public InvalidParamsException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class UnknownLocationException : PostmatesExceptionBase
    {
        public UnknownLocationException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class InvalidApiVersionException : PostmatesExceptionBase
    {
        public InvalidApiVersionException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class AddressUndeliverableException : PostmatesExceptionBase
    {
        public AddressUndeliverableException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class ExpiredQuoteException : PostmatesExceptionBase
    {
        public ExpiredQuoteException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class UsedQuoteException : PostmatesExceptionBase
    {
        public UsedQuoteException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class MismatchedPriceQuoteException : PostmatesExceptionBase
    {
        public MismatchedPriceQuoteException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class MissingPaymentException : PostmatesExceptionBase
    {
        public MissingPaymentException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class MaxTipExceededException : PostmatesExceptionBase
    {
        public MaxTipExceededException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class TipAlreadyRecordedErrorException : PostmatesExceptionBase
    {
        public TipAlreadyRecordedErrorException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class NoTipException : PostmatesExceptionBase
    {
        public NoTipException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class InvalidTippingStateException : PostmatesExceptionBase
    {
        public InvalidTippingStateException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class NoncancelableDeliveryException : PostmatesExceptionBase
    {
        public NoncancelableDeliveryException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class PickupReadyTimeNotSpecifiedException : PostmatesExceptionBase
    {
        public PickupReadyTimeNotSpecifiedException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class PickupWindowTooSmallException : PostmatesExceptionBase
    {
        public PickupWindowTooSmallException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class DropoffDeadlineTooEarlyException : PostmatesExceptionBase
    {
        public DropoffDeadlineTooEarlyException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class DropoffDeadlineBeforePickupDeadlineException : PostmatesExceptionBase
    {
        public DropoffDeadlineBeforePickupDeadlineException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class DropoffReadyAfterPickupDeadlineException : PostmatesExceptionBase
    {
        public DropoffReadyAfterPickupDeadlineException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class PickupReadyTooEarlyException : PostmatesExceptionBase
    {
        public PickupReadyTooEarlyException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class PickupDeadlineTooEarlyException : PostmatesExceptionBase
    {
        public PickupDeadlineTooEarlyException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class PickupReadyTooLateException : PostmatesExceptionBase
    {
        public PickupReadyTooLateException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class CardInvalidException : PostmatesExceptionBase
    {
        public CardInvalidException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class CardDuplicateException : PostmatesExceptionBase
    {
        public CardDuplicateException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class CardExpiredException : PostmatesExceptionBase
    {
        public CardExpiredException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class CardDeclinedException : PostmatesExceptionBase
    {
        public CardDeclinedException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class CustomerSuspendedException : PostmatesExceptionBase
    {
        public CustomerSuspendedException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class CustomerBlockedException : PostmatesExceptionBase
    {
        public CustomerBlockedException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class CatalogAccessForbiddenException : PostmatesExceptionBase
    {
        public CatalogAccessForbiddenException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class CustomerNotFoundException : PostmatesExceptionBase
    {
        public CustomerNotFoundException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class DeliveryNotFoundException : PostmatesExceptionBase
    {
        public DeliveryNotFoundException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class AccountNotFoundException : PostmatesExceptionBase
    {
        public AccountNotFoundException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class QuoteNotFoundException : PostmatesExceptionBase
    {
        public QuoteNotFoundException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class DeveloperNotFoundException : PostmatesExceptionBase
    {
        public DeveloperNotFoundException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class WebhookNotFoundException : PostmatesExceptionBase
    {
        public WebhookNotFoundException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class FenceNotFoundException : PostmatesExceptionBase
    {
        public FenceNotFoundException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class CatalogUpdateJobNotFoundException : PostmatesExceptionBase
    {
        public CatalogUpdateJobNotFoundException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class RequestTimeoutException : PostmatesExceptionBase
    {
        public RequestTimeoutException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class CustomerLimitedException : PostmatesExceptionBase
    {
        public CustomerLimitedException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class CouriersBusyException : PostmatesExceptionBase
    {
        public CouriersBusyException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class RoboCouriersBusyException : PostmatesExceptionBase
    {
        public RoboCouriersBusyException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }

    public class ServiceUnavailableException : PostmatesExceptionBase
    {
        public ServiceUnavailableException(PostmatesExceptionArgs postmatesExceptionArgs) : base(postmatesExceptionArgs) { }
    }
}
