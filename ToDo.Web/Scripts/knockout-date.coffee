ko.bindingHandlers.date =
    update: (element, valueAccessor) ->
        theDate = ko.utils.unwrapObservable(valueAccessor())

        if theDate? and theDate not instanceof Date
            throw new TypeError("The date binding must be bound to a Date object on the view model.")

        isJustDateNotDateTime = theDate?.getUTCHours() is 0 and theDate?.getUTCMinutes() is 0 and theDate?.getUTCSeconds() is 0 and theDate?.getUTCMilliseconds() is 0
        isoDateTimeString = theDate?.toISOString()
        isoDateString = isoDateTimeString?.substring(0, 10)
        isoTimeString = isoDateTimeString?.substring(11, 19)
        
        tagName = element.tagName.toLowerCase()
        $element = $(element)
        if tagName is "time"
            $element.attr("datetime", isoDateTimeString)
            $element.text(if isJustDateNotDateTime then isoDateString else isoDateTimeString)
        else if tagName is "input"
            switch element.getAttribute("type")
                when "datetime"
                    $element.val(isoDateTimeString)
                when "datetime-local"
                    throw new Error("I really should support this but I just don't see the use case yet")
                when "date"
                    $element.val(isoDateString)
                when "time"
                    $element.val(isoTimeString)
                else
                    throw new Error("Unsupported input type for date binding.")
        else
            throw new Error("Unsupported tag for date binding.")