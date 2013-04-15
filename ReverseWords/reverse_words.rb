class ReverseWords

  def self.reverse_sentence!(sentence)
    reverse_string!(sentence, 0, sentence.length - 1)
    beginning = 0
    for i in 0..sentence.length
      if i == sentence.length || sentence[i] == ' '
        reverse_string!(sentence, beginning, i - 1)
        beginning = i + 1
      end
    end
  end

  private
  def self.reverse_string!(string, beginning, ending)
    mid = find_mid(beginning, ending)
    end_idx = ending
    for i in beginning..mid
      swap_chars!(string, i, end_idx)
      end_idx = ending -= 1
    end
  end

  def self.find_mid(beginning, ending)
    beginning + ((ending - beginning) / 2)
  end

  def self.swap_chars!(string, idx, end_idx)
    placeholder = string[idx]
    string[idx] = string[end_idx]
    string[end_idx] = placeholder
  end

end