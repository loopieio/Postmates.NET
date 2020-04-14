//-----------------------------------------------------------------------------
// FILE:	    PostmatesExceptionThrower.cs
// CONTRIBUTOR: Ian White
// COPYRIGHT:	Copyright (c) 2018-2020 by Loopie, Inc.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

using Neon.Net;

using Postmates;

namespace Postmates
{
    public static class PostmatesExceptionThrower
    {
        public static Exception GetException(PostmatesExceptionArgs postmatesExceptionArgs)
        {
            switch (postmatesExceptionArgs.Code)
            {
                case PostmatesErrorCodes.Forbidden:
                    return new ForbiddenException(postmatesExceptionArgs);

                case PostmatesErrorCodes.UnknownError:
                    return new UnknownErrorException(postmatesExceptionArgs);

                case PostmatesErrorCodes.DuplicateDelivery:
                    return new DuplicateDeliveryException(postmatesExceptionArgs);

                case PostmatesErrorCodes.InvalidParams:
                    return new InvalidParamsException(postmatesExceptionArgs);

                case PostmatesErrorCodes.UnknownLocation:
                    return new UnknownLocationException(postmatesExceptionArgs);

                case PostmatesErrorCodes.InvalidApiVersion:
                    return new InvalidApiVersionException(postmatesExceptionArgs);

                case PostmatesErrorCodes.AddressUndeliverable:
                    return new AddressUndeliverableException(postmatesExceptionArgs);

                case PostmatesErrorCodes.ExpiredQuote:
                    return new ExpiredQuoteException(postmatesExceptionArgs);

                case PostmatesErrorCodes.UsedQuote:
                    return new UsedQuoteException(postmatesExceptionArgs);

                case PostmatesErrorCodes.MismatchedPriceQuote:
                    return new MismatchedPriceQuoteException(postmatesExceptionArgs);

                case PostmatesErrorCodes.MissingPayment:
                    return new MissingPaymentException(postmatesExceptionArgs);

                case PostmatesErrorCodes.MaxTipExceeded:
                    return new MaxTipExceededException(postmatesExceptionArgs);

                case PostmatesErrorCodes.TipAlreadyRecordedError:
                    return new TipAlreadyRecordedErrorException(postmatesExceptionArgs);

                case PostmatesErrorCodes.NoTip:
                    return new NoTipException(postmatesExceptionArgs);

                case PostmatesErrorCodes.InvalidTippingState:
                    return new InvalidTippingStateException(postmatesExceptionArgs);

                case PostmatesErrorCodes.NoncancelableDelivery:
                    return new NoncancelableDeliveryException(postmatesExceptionArgs);

                case PostmatesErrorCodes.PickupReadyTimeNotSpecified:
                    return new PickupReadyTimeNotSpecifiedException(postmatesExceptionArgs);

                case PostmatesErrorCodes.PickupWindowTooSmall:
                    return new PickupWindowTooSmallException(postmatesExceptionArgs);

                case PostmatesErrorCodes.DropoffDeadlineTooEarly:
                    return new DropoffDeadlineTooEarlyException(postmatesExceptionArgs);

                case PostmatesErrorCodes.DropoffDeadlineBeforePickupDeadline:
                    return new DropoffDeadlineBeforePickupDeadlineException(postmatesExceptionArgs);

                case PostmatesErrorCodes.DropoffReadyAfterPickupDeadline:
                    return new DropoffReadyAfterPickupDeadlineException(postmatesExceptionArgs);

                case PostmatesErrorCodes.PickupReadyTooEarly:
                    return new PickupReadyTooEarlyException(postmatesExceptionArgs);

                case PostmatesErrorCodes.PickupDeadlineTooEarly:
                    return new PickupDeadlineTooEarlyException(postmatesExceptionArgs);

                case PostmatesErrorCodes.PickupReadyTooLate:
                    return new PickupReadyTooLateException(postmatesExceptionArgs);

                case PostmatesErrorCodes.CardInvalid:
                    return new CardInvalidException(postmatesExceptionArgs);

                case PostmatesErrorCodes.CardDuplicate:
                    return new CardDuplicateException(postmatesExceptionArgs);

                case PostmatesErrorCodes.CardExpired:
                    return new CardExpiredException(postmatesExceptionArgs);

                case PostmatesErrorCodes.CardDeclined:
                    return new CardDeclinedException(postmatesExceptionArgs);

                case PostmatesErrorCodes.CustomerSuspended:
                    return new CustomerSuspendedException(postmatesExceptionArgs);

                case PostmatesErrorCodes.CustomerBlocked:
                    return new CustomerBlockedException(postmatesExceptionArgs);

                case PostmatesErrorCodes.CatalogAccessForbidden:
                    return new CatalogAccessForbiddenException(postmatesExceptionArgs);

                case PostmatesErrorCodes.CustomerNotFound:
                    return new CustomerNotFoundException(postmatesExceptionArgs);

                case PostmatesErrorCodes.DeliveryNotFound:
                    return new DeliveryNotFoundException(postmatesExceptionArgs);

                case PostmatesErrorCodes.AccountNotFound:
                    return new AccountNotFoundException(postmatesExceptionArgs);

                case PostmatesErrorCodes.QuoteNotFound:
                    return new QuoteNotFoundException(postmatesExceptionArgs);

                case PostmatesErrorCodes.DeveloperNotFound:
                    return new DeveloperNotFoundException(postmatesExceptionArgs);

                case PostmatesErrorCodes.WebhookNotFound:
                    return new WebhookNotFoundException(postmatesExceptionArgs);

                case PostmatesErrorCodes.FenceNotFound:
                    return new FenceNotFoundException(postmatesExceptionArgs);

                case PostmatesErrorCodes.CatalogUpdateJobNotFound:
                    return new CatalogUpdateJobNotFoundException(postmatesExceptionArgs);

                case PostmatesErrorCodes.RequestTimeout:
                    return new RequestTimeoutException(postmatesExceptionArgs);

                case PostmatesErrorCodes.CustomerLimited:
                    return new CustomerLimitedException(postmatesExceptionArgs);

                case PostmatesErrorCodes.CouriersBusy:
                    return new CouriersBusyException(postmatesExceptionArgs);

                case PostmatesErrorCodes.RoboCouriersBusy:
                    return new RoboCouriersBusyException(postmatesExceptionArgs);

                case PostmatesErrorCodes.ServiceUnavailable:
                    return new ServiceUnavailableException(postmatesExceptionArgs);

                default:
                    throw new Exception("Something went wrong");
            }
        }
    }
}
